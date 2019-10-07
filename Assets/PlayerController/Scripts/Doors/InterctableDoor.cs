using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterctableDoor : Door
{
    protected override void Start()
    {
        base.Start();
        BoxCollider b = gameObject.AddComponent<BoxCollider>();
        b.size = door.localScale;
        b.isTrigger = true;

    }
}
