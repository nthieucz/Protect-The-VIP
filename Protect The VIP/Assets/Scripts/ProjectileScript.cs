using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public Vector3 direction;
    private float lifeSpan = 0;
    public float speed;
    public GameObject vip;
    public GameObject hitManager;
    public GameObject gameobject;

    private void Start()
    {
        vip = GameObject.Find("VIP");

    }
    void Update()
    {
        gameObject.transform.Translate(direction * Time.deltaTime * speed);
        lifeSpan += Time.deltaTime;
        if (lifeSpan > 50)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 diff = vip.transform.position - gameObject.transform.position;
        Destroy(gameObject);
        //Debug.Log("diff: " + diff.x + " / " + diff.y);
        //if (Mathf.Abs(diff.y) > 3) return;
        //if (Mathf.Abs(diff.x) > 10) return;



        
    }
}
