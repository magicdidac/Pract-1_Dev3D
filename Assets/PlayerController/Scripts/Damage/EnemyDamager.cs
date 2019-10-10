using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamager : Damager
{

    [Header("Prefabs")]
    [SerializeField] private GameObject ammoPickable = null;
    [SerializeField] private GameObject healthPickable = null;
    [SerializeField] private GameObject shieldPickable = null;

    [SerializeField] private Image lifeBar = null;
    [SerializeField] private Image lifeBarColor = null;
    [SerializeField] private Image lifeBarWhite = null;
    [SerializeField] private float lifeBarOffsetY = 0;

    [SerializeField] private RectTransform lifeBarCanvas = null;

    [HideInInspector] private bool invisible = false;

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

    private void Update()
    {
        if ((transform.position - GameManager.instance.player.transform.position).magnitude < 7 && !invisible)
        {
            lifeBarWhite.fillAmount = (Vector2.MoveTowards(new Vector2(lifeBarWhite.fillAmount, 0), new Vector2(lifeBarColor.fillAmount, 0), .5f * Time.deltaTime)).x;
            lifeBarColor.fillAmount = (float)health / maxHealth;
            UpdateLifeBarPosition();
        }
        else
            lifeBar.gameObject.SetActive(false);
    }

    private void UpdateLifeBarPosition()
    {
        lifeBar.gameObject.SetActive(true);
        Vector3 l_ViewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.up * lifeBarOffsetY);
        lifeBar.rectTransform.anchoredPosition = new Vector3(l_ViewportPoint.x * lifeBarCanvas.sizeDelta.x, - (1.0f - l_ViewportPoint.y) * lifeBarCanvas.sizeDelta.y, 0.0f);
    }

    private void OnBecameInvisible()
    {
        invisible = true;
    }

    private void OnWillRenderObject()
    {
        invisible = false;
    }

}
