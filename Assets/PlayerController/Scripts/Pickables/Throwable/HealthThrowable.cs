using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthThrowable : ThrowablePickable
{
    [SerializeField] private int healthGive = 10;

    protected override void GetPickable()
    {
        if (!gm.player.dmgShield.HaveMaxHealth())
        {
            gm.player.dmgShield.AddHealth(healthGive);
            Destroy(gameObject);
        }
    }
}
