using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    [HideInInspector] private Platform plat;
    [HideInInspector] private Vector3 nextPos;
    [HideInInspector] private float nextTime = 0;

    private void Start()
    {
        plat = transform.parent.GetComponent<Platform>();
        nextPos = (plat.isPlayerRequired)? transform.localPosition : plat.NextPos();
    }

    public void Move()
    {
        if(plat.isPlayerRequired)
            nextPos = plat.NextPos();
    }

    public bool IsPlayerRequired()
    {
        return plat.isPlayerRequired;
    }

    public bool BackToStart()
    {
        return plat.backToStart;
    }

    private void FixedUpdate()
    {

        if(nextPos != transform.localPosition && Time.time > nextTime)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, plat.speed * Time.deltaTime);
        }
        else if(nextPos == transform.localPosition && !plat.isPlayerRequired)
        {
            nextTime = Time.time + plat.waitTime;
            nextPos = plat.NextPos();
        }
    }


}
