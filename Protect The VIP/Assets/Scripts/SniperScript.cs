using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject destructiblePrefab;
    public GameObject physicsPrefab;

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;
    public Vector3 pos5;

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

        if (Input.GetMouseButtonDown(2))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            GameObject newPhysics = Instantiate(physicsPrefab);
            newPhysics.transform.position = worldPosition;
        }

        if (Input.GetKeyDown("1"))
        {
            if (pos1.x == 0 && pos1.y == 0) return; gameObject.transform.position = pos1;
        }
        if (Input.GetKeyDown("2"))
        {
            if (pos2.x == 0 && pos2.y == 0) return; gameObject.transform.position = pos2;
        }
        if (Input.GetKeyDown("3"))
        {
            if (pos3.x == 0 && pos3.y == 0) return; gameObject.transform.position = pos3;
        }
        if (Input.GetKeyDown("4"))
        {
            if (pos4.x == 0 && pos4.y == 0) return; gameObject.transform.position = pos4;
        }
        if (Input.GetKeyDown("5"))
        {
            if (pos5.x == 0 && pos5.y == 0) return; gameObject.transform.position = pos5;
        }
    }

    void shoot(Vector3 initial, Vector3 final)
    {
        Vector3 direction = final - initial;

        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = initial;
        projectile.GetComponent<ProjectileScript>().direction = direction.normalized;
    }
}