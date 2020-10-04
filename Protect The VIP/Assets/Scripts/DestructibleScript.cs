using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleScript : MonoBehaviour
{
    public GameObject destroyEffect;
    public AudioClip audio;
    private SFXManager sfxManager;
    private void Start()
    {
        sfxManager = GameObject.Find("SFX Manager").GetComponent<SFXManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            sfxManager.playAudio(audio);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
