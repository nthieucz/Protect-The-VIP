using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{

    private Vector3 startPos;
    public Vector3 endPos;
    public float ticksToReachEnd;
    private Vector3 step;
    public bool isStopped = false;

    void Start()
    {
        startPos = gameObject.transform.position;
        step = (endPos - startPos) / ticksToReachEnd;
    }

    int ticks = 0;
    bool isGoingBack = false;
    void FixedUpdate()
    {
        if (isStopped) return;

        if (!isGoingBack)
        {
            gameObject.transform.Translate(step);
            ticks++;
            if (ticks == ticksToReachEnd)
            {
                isGoingBack = true;
            }
        }
        else
        {
            gameObject.transform.Translate(-step);
            ticks--;
            if (ticks == 0)
            {
                isGoingBack = false;
            }
        }
    }

    public void toggleStop()
    {
        isStopped = !isStopped;
    }
}
