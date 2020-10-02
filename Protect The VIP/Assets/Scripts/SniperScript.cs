using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject destructiblePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            this.shoot(gameObject.transform.position, worldPosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            GameObject newDestructible = Instantiate(destructiblePrefab);
            newDestructible.transform.position = worldPosition;
        }
    }

    void shoot(Vector3 initial, Vector3 final)
    {
        Vector3 direction = final - initial;

        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = initial;
        projectile.GetComponent<ProjectileScript>().direction = direction.normalized; ;
    }
}