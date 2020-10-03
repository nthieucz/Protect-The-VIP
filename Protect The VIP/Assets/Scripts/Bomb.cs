﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
