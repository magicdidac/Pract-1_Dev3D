using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : InterctableDoor
{

    [SerializeField] private Key key = null;

    [HideInInspector] private bool isKeyCollected = false;


    protected override void Start()
    {
        base.Start();
        key.SetDoor(this);

    }

    public override bool CanInteractIt()
    {
        return isKeyCollected;
    }

    public void KeyCollected()
    {
        isKeyCollected = true;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.black;

        Gizmos.matrix = Matrix4x4.identity;

        if(door != null)
            Gizmos.DrawLine(transform.position, key.transform.position);

    }
}
