using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeBar : MonoBehaviour
{

    [SerializeField] private Image lifeBar = null;
    [SerializeField] private Vector3 offset = Vector2.zero;
    [HideInInspector] public Damager dmgr;

    private void Update()
    {
        try
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(dmgr.transform.position + offset);
            transform.position = screenPosition;

            lifeBar.fillAmount = dmgr.health / dmgr.maxHealth;

        }
        catch { Destroy(gameObject); }
    }

}
