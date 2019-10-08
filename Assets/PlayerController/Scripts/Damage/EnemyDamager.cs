using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : Damager
{

    [Header("Prefabs")]
    [SerializeField] private GameObject ammoPickable = null;
    [SerializeField] private GameObject healthPickable = null;
    [SerializeField] private GameObject shieldPickable = null;

    [HideInInspector] public GameObject lifeBar = null;

    public override void GetDammage(int amount)
    {
        health -= amount;

        if (health <= 0)
            Die();

    }

    private void Die()
    {
        SpawnPickable(-1, 3, ammoPickable);
        SpawnPickable(1, 2, healthPickable);
        SpawnPickable(-5, 2, shieldPickable);

        Destroy(gameObject);
    }

    private void SpawnPickable(int minPickable, int maxPickables, GameObject pickable)
    {
        int rngNumber = Random.Range(minPickable, maxPickables + 1);

        for (int i = 0; i < rngNumber; i++)
        {
            Instantiate(pickable, transform.position, Quaternion.identity);
        }
    }

}
