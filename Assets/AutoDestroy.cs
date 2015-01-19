using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    float _timeToDestroy = 3f;

    void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
