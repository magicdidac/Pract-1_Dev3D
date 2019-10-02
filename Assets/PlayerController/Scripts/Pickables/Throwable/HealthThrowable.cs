﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthThrowable : ThrowablePickable
{
    [SerializeField] private int healthGive = 10;

    public override void GetPickable(FPSController player)
    {
        if (!player.dmgShield.HaveMaxHealth())
        {
            player.dmgShield.AddHealth(healthGive);
            Destroy(gameObject);
        }
    }
}
