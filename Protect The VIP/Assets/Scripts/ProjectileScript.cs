using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public Vector3 direction;
    private float lifeSpan = 0;
    public float speed;
    public GameObject vip;
   
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
        Vector3 diff = vip.transform.position - gameObject.transform.position;
        Destroy(gameObject);
        Debug.Log("diff: " + diff.x + " / " + diff.y);
        //if (Mathf.Abs(diff.y) > 3) return;
        //if (Mathf.Abs(diff.x) > 10) return;
        vip.GetComponent<VIPScript>().Hit(diff.x > 0 ? 1 : -1);

        
    }
}
