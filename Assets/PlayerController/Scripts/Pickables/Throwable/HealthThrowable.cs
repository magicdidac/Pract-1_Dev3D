using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthThrowable : ThrowablePickable
{
    [SerializeField] private int healthGive = 10;

    public override bool CanTakeIt()
    {
        try {
            return !gm.player.dmgShield.HaveMaxHealth();
        }
        catch { return false; }
    }

    protected override void NowGetPickable()
    {
        gm.player.dmgShield.AddHealth(healthGive);
        Destroy(gameObject);
    }
}
