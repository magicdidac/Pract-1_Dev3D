using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickable : Pickable
{
    public override bool CanTakeIt()
    {
        return !gm.player.haveGun;
    }

    protected override void NowGetPickable()
    {
        gm.player.haveGun = true;
        gm.player.gun.gameObject.SetActive(true);
        gm.player.uiController.SetActiveGunInfo();
        Destroy(gameObject);
    }
}
