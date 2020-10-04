using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expolsion : MonoBehaviour
{
    public AudioClip audio;
    private SFXManager sfxManager;
    private float timer;
    public float timerStart;

    // Start is called before the first frame update
    void Start()
    {
        sfxManager = GameObject.Find("SFX Manager").GetComponent<SFXManager>();
        sfxManager.playAudio(audio);
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
