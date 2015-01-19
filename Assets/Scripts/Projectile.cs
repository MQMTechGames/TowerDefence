using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    float _speed = 200f;

    Vector3 _originPosition;
    Vector3 _direction;
    string _targetTag;

    void Awake()
    {
        enabled = false;
    }

    public void Fire(Vector3 originPosition, Vector3 targetPosition, string targetTag)
    {
        _originPosition = originPosition;
        _direction = (targetPosition - _originPosition).normalized;
        _targetTag = targetTag;

        transform.position = _originPosition;

        enabled = true;
    }

    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!enabled)
        {
            return;
        }

        if (other.gameObject.CompareTag(_targetTag))
        {
            other.gameObject.SendMessage("OnProjectileHit");
        }
    }
}
