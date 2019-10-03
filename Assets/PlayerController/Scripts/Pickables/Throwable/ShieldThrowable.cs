using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrowable : ThrowablePickable
{
    [SerializeField] private int shieldGive = 10;

    protected override void GetPickable()
    {
        if (!gm.player.dmgShield.HaveMaxShield())
        {
            gm.player.dmgShield.AddShield(shieldGive);
            Destroy(gameObject);
        }
    }
}
