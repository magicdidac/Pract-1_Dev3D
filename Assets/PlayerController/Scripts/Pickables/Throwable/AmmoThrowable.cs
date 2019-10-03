using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoThrowable : ThrowablePickable
{
    [SerializeField] private int ammoGive = 10;

    protected override void GetPickable()
    {
        if (gm.player.haveGun && !gm.player.gun.HaveMaxAmmo())
        {
            gm.player.gun.AddAmmo(ammoGive);
            Destroy(gameObject);
        }
    }
}
