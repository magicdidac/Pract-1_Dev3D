using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickable : Pickable
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
