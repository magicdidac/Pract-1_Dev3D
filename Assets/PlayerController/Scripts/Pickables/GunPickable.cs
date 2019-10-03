using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickable : Pickable
{
    protected override void GetPickable()
    {
        gm.player.haveGun = true;
        gm.player.gun.gameObject.SetActive(true);
        gm.player.uiController.SetActiveGunInfo();
        Destroy(gameObject);
    }
}
