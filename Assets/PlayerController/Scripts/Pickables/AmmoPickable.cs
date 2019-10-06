using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickable : Pickable
{

    [SerializeField] private int ammoGive = 10;

    public override bool CanInteractIt()
    {
        return base.CanInteractIt() && gm.player.haveGun && !gm.player.gun.HaveMaxAmmo();
    }

    protected override void NowGetPickable()
    {
        gm.player.gun.AddAmmo(ammoGive);
        Destroy(gameObject);
    }
}
