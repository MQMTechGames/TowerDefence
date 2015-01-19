using UnityEngine;
using System.Collections;

[System.Serializable]
public class WaveConfig : MonoBehaviour
{
    [SerializeField]
    public float SpawnRate = 0.5f;
    [SerializeField]
    public int NumberOfAttackers = 1;
    [SerializeField]
    public Vector3 StartPosition;
    [SerializeField]
    public Vector3 EndPosition;
    [SerializeField]
    public Vector3 FrontDir = Vector3.forward;

    [SerializeField]
    public EnemyDemo EnemeyPrefab;
    [SerializeField]
    public float WaitTime = 10f;

    int attackersCount = 0;

    public void Play()
    {
        attackersCount = 0;
        Invoke("DoPlay", SpawnRate);
    }

    void DoPlay()
    {
        SpawnAttacker();
        attackersCount ++;
        if (attackersCount < NumberOfAttackers)
        {
            Invoke("DoPlay", SpawnRate);
        }
    }

    void SpawnAttacker()
    {
        EnemyDemo attacker = GameObject.Instantiate(EnemeyPrefab, StartPosition, Quaternion.identity) as EnemyDemo;
    }
}
