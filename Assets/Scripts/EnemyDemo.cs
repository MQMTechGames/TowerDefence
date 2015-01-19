using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class EnemyDemo : MonoBehaviour
{
    [SerializeField]
    float _life = 15f;

    [SerializeField]
    Vector3 _destination;
    NavMeshAgent _agent;

    public void Init(Vector3 destination)
    {
        _destination = destination;
    }

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        _agent.SetDestination(_destination);
    }

    void Update()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                Kill();
            }
        }
    }

    void OnProjectileHit()
    {
        _life -= 1f;

        if (_life <= 0f)
        {
            Kill();
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
