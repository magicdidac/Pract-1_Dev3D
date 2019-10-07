using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Platform : MonoBehaviour
{

    [HideInInspector] public Vector3 initialPos;
    [HideInInspector] private Vector3 oldPos;
    [HideInInspector] public Vector3[] nextPos;
    [HideInInspector] public float speed = 1;
    [HideInInspector] public bool isPlayerRequired;
    [HideInInspector] public bool backToStart;
    [HideInInspector] public float waitTime = .5f;

    [HideInInspector] private Transform platform;
    [HideInInspector] private int nextIndexPos = 0;

    private void Awake()
    {
        platform = transform.GetChild(0);

        initialPos = platform.position;
        oldPos = platform.position;
    }


    public Vector3 NextPos()
    {
        if(nextIndexPos >= nextPos.Length)
        {
            nextIndexPos = 0;
            oldPos = initialPos;
            return initialPos;
        }
        else
        {
            oldPos += nextPos[nextIndexPos];
            nextIndexPos++;
            return oldPos;
        }
    }


    private void OnDrawGizmos()
    {
        if (platform == null)
            platform = transform.GetChild(0);


        Gizmos.color = new Color(0, 255, 0, .5f);

        Gizmos.DrawCube(platform.position, platform.localScale * 1.1f);

        Gizmos.color = new Color(255, 0, 0, .5f);

        if (nextPos == null)
            return;

        Vector3 oldPos;

        if (!Application.isPlaying)
            oldPos = platform.position;
        else
            oldPos = this.initialPos;

        if (!isPlayerRequired)
        {
            foreach (Vector3 pos in nextPos)
            {
                Gizmos.DrawCube(oldPos + pos, platform.localScale);
                oldPos += pos;
            }
        }
        else
        {
            Gizmos.DrawCube(oldPos + nextPos[0], platform.localScale);
        }

    }

}
