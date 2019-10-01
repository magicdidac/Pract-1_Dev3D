using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [HideInInspector] public Vector3 initialPos;
    [SerializeField] private Vector3[] nextPos = null;
    [HideInInspector] private Vector3 oldPos;
    [SerializeField] public float speed = 1;
    [SerializeField] public bool isPlayerRequired = true;
    [SerializeField] public bool backToStart = true;
    [SerializeField] public float waitTime = .5f;

    [HideInInspector] private Transform platform;
    [HideInInspector] private int nextIndexPos = 0;

    private void Awake()
    {
        platform = transform.GetChild(0);
        platform.tag = "Platform";


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

        Vector3 oldPos = platform.position;

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
