using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    [SerializeField] public int maxHealth = 100;
    [SerializeField] private bool isPlayer = true;
    [HideInInspector] public int health;
    [HideInInspector] protected GameManager gm;

    [SerializeField] private GameObject ammoPickable = null;
    [SerializeField] private GameObject healthPickable = null;
    [SerializeField] private GameObject shieldPickable = null;

    protected void Start()
    {
        health = maxHealth;

        gm = GameManager.instance;
    }

    public virtual void GetDammage(int amount)
    {
        health -= amount;

        if (!isPlayer && health <= 0)
        {
            Die();
        }

    }

    public void AddHealth(int ammount)
    {
        health += ammount;
        if (health > maxHealth)
            health = maxHealth;

    }

    public bool HaveMaxHealth()
    {
        return health >= maxHealth;
    }

    private void Die()
    {
        SpawnPickable(-1, 3, ammoPickable);
        SpawnPickable(-5, 2, healthPickable);
        SpawnPickable(-5, 3, shieldPickable);

        Destroy(gameObject);
    }

    private void SpawnPickable(int minPickable, int maxPickables, GameObject pickable)
    {
        int rngNumber = Random.Range(minPickable, maxPickables+1);

        for(int i = 0; i<rngNumber; i++)
        {
            Instantiate(pickable, transform.position, Quaternion.identity);
        }

        

    }


}
