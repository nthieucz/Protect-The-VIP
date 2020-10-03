using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expolsion : MonoBehaviour
{
    private float timer;
    public float timerStart;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerStart)
        {
            Destroy(gameObject);
        }
    }
}
