using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    [SerializeField]
    Projectile _projectilePrefab;

    [SerializeField]
    float _fireRate = 0.35f;

    [SerializeField]
    Transform _torretModel;

    [SerializeField]
    Transform _bulletSpawnPoint;

    Timer _timer;

    void OnTriggerStay(Collider other)
    {
        GameObject targetGO = other.gameObject;

        if (targetGO.CompareTag(Tags.Attacker))
        {
            if (_timer.IsEnd())
            {
                ShootProjectile(targetGO.transform.position, targetGO.tag);
                _timer.Wait(_fireRate);

                if(_torretModel)
                {
                    Vector3 targetDir = (targetGO.transform.position - transform.position).normalized;
                    Quaternion rotation = Quaternion.LookRotation(targetDir);

                    _torretModel.rotation = rotation;
                }
            }
        }
    }

    void ShootProjectile(Vector3 targetPosition, string targetTag)
    {
        Projectile projectile = Instantiate(_projectilePrefab) as Projectile;

        projectile.Fire(_bulletSpawnPoint.position, targetPosition + Vector3.up * 2f, targetTag);
    }
}
