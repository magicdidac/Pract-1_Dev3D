using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoThrowable : ThrowablePickable
{
    [SerializeField] private int ammoGive = 10;

    public override void GetPickable(FPSController player)
    {
        if (player.haveGun && !player.gun.HaveMaxAmmo())
        {
            player.gun.AddAmmo(ammoGive);
            Destroy(gameObject);
        }
    }
}
