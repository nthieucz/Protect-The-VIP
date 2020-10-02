using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    public int hitDirection;
    public bool hitRegistered;


    public void Hit(int dir)
    {
        Debug.Log("hit called with dir = " + dir);
        Debug.Log(hitDirection + "/" + hitRegistered);
        hitDirection = dir;
        hitRegistered = true;

        Debug.Log(hitDirection + "/" + hitRegistered);
    }
}
