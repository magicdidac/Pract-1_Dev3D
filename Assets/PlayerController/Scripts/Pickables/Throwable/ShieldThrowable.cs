using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrowable : ThrowablePickable
{
    [SerializeField] private int shieldGive = 10;

    public override bool CanTakeIt()
    {
        try
        {
            return !gm.player.dmgShield.HaveMaxShield();
        }
        catch { return false; }
    }

    protected override void NowGetPickable()
    {
        gm.player.dmgShield.AddShield(shieldGive);
        Destroy(gameObject);
    }
}
