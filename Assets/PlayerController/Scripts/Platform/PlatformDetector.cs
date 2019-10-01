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
        nextPos = (plat.isPlayerRequired)? transform.position : plat.NextPos();
    }

    public void Move()
    {
        if(plat.isPlayerRequired)
            nextPos = plat.NextPos();
    }

    private void OnTriggerExit(Collider other)
    {
        if (plat.isActiveAndEnabled && plat.backToStart)
            nextPos = plat.NextPos();

        transform.GetChild(0).parent = null;
    }

    private void FixedUpdate()
    {
        if(nextPos != transform.position && Time.time > nextTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, plat.speed * Time.deltaTime);
        }
        else if(nextPos == transform.position && !plat.isPlayerRequired)
        {
            nextTime = Time.time + plat.waitTime;
            nextPos = plat.NextPos();
        }
    }


}
