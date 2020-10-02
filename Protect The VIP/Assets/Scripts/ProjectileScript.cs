using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public Vector3 direction;
    private float lifeSpan = 0;
    public float speed;
   
    void Update()
    {
        gameObject.transform.Translate(direction * Time.deltaTime * speed);
        lifeSpan += Time.deltaTime;
        if (lifeSpan > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
    }
}
