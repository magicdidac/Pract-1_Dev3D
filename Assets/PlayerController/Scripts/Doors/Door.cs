using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] protected bool isOpened = false;

    [SerializeField] protected Vector3 openPositiom = Vector3.zero;
    [HideInInspector] protected Vector3 closePositiom = Vector3.zero;

    [SerializeField] protected float speed = 2;

    private void Start()
    {
        closePositiom = transform.position;
    }

    public virtual void UseDoor()
    {
        isOpened = !isOpened;
    }

    private void FixedUpdate()
    {
        if (isOpened && transform.position != closePositiom + openPositiom)
            transform.position = Vector3.MoveTowards(transform.position, closePositiom + openPositiom, speed);
        else if (!isOpened && transform.position != closePositiom)
            transform.position = Vector3.MoveTowards(transform.position, closePositiom, speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 255, 0, .5f);

        Gizmos.DrawCube(transform.position, transform.localScale * 1.1f);

        if (openPositiom == Vector3.zero)
            return;

        Gizmos.color = new Color(255, 0, 0, .5f);

        if (closePositiom == Vector3.zero)
            closePositiom = transform.position;

        Gizmos.DrawCube(closePositiom + openPositiom, transform.localScale + (Vector3.forward * 0.3f));

    }


}
