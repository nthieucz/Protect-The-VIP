using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    private float lifeSpan = 0;
    public float speed;
    public GameObject vip;
    public GameObject gameobject;

    private void Start()
    {
        vip = GameObject.Find("VIP");

    }
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
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
