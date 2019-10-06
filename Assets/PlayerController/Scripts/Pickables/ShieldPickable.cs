using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickable : Pickable
{
    [SerializeField] private int shieldGive = 10;

    public override bool CanInteractIt()
    {
        return base.CanInteractIt() && !gm.player.dmgShield.HaveMaxShield();
    }

    protected override void NowGetPickable()
    {
        gm.player.dmgShield.AddShield(shieldGive);
        Destroy(gameObject);
    }
}
