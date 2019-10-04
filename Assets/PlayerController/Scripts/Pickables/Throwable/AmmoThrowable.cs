using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoThrowable : ThrowablePickable
{
    [SerializeField] private int ammoGive = 10;

    public override bool CanTakeIt()
    {
        try
        {
            return gm.player.haveGun && !gm.player.gun.HaveMaxAmmo();
        }catch { return false; }
    }

    protected override void NowGetPickable()
    {
        gm.player.gun.AddAmmo(ammoGive);
        Destroy(gameObject);
    }
}
