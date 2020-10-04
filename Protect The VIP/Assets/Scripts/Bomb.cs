using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Projectile")) return;

        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
