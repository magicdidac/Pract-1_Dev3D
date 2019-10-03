using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ThrowablePickable : Pickable
{
    [HideInInspector] private Rigidbody rb;
    [SerializeField] private Collider col = null;

    [SerializeField] private float force = 1;
    [SerializeField] private float maxDispersion = 2;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;

        rb.AddForce(new Vector3(Random.Range(-maxDispersion, maxDispersion), force, Random.Range(-maxDispersion, maxDispersion)), ForceMode.Impulse);

        col.enabled = false;
    }

    protected virtual void Update()
    {
        if (rb.velocity.y < -0.1f)
            col.enabled = true;
        else
            col.enabled = false;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            col.enabled = false;
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

}
