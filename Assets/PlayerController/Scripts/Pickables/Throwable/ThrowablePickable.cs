using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ThrowablePickable : Pickable
{
    [HideInInspector] private Rigidbody rb;
    [SerializeField] private Collider col = null;

    [HideInInspector] private bool checkRay = true;

    [SerializeField] private float force;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;

        rb.AddForce(new Vector3(Random.Range(-5f, 5f), force, Random.Range(-5f, 5f)), ForceMode.Impulse);

        col.enabled = false;
    }

    protected virtual void Update()
    {

        if (!Physics.Raycast(transform.position, Vector3.down, .5f))
        {
            
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        if (rb.velocity.y < 0)
            col.enabled = true;
        else
            col.enabled = false;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Pickable")
        {
            col.enabled = false;
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

}
