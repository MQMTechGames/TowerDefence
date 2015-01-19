using UnityEngine;
using System.Collections;

public class DefenseCreator : MonoBehaviour
{
    [SerializeField]
    Tower _towerPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 99999f, 1 << LayerMask.NameToLayer("Terrain")))
            {
                Instantiate(_towerPrefab, hit.point, transform.rotation);
            }
        }
    }
}
