using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{

    [SerializeField] private float damageMultiplier = 1;
    [SerializeField] private Damager dmg = null;


    public void ReviveDamage(int amount)
    {
        int damage = (int)(amount * damageMultiplier);
        dmg.GetDammage(damage);
        FloatingTextController.CreateFloatingText(damage.ToString(), gameObject);
    }

}
