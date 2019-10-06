using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickable : Pickable
{

    [SerializeField] private int healthGive = 10;

    public override bool CanInteractIt()
    {
        return base.CanInteractIt() && !gm.player.dmgShield.HaveMaxHealth();
    }

    protected override void NowGetPickable()
    {
        gm.player.dmgShield.AddHealth(healthGive);
        Destroy(gameObject);
    }

}
