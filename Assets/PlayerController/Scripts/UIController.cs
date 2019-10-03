﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameObject healthShieldInfoPanel = null;
    [SerializeField] private GameObject gunInfoPanel = null;
    [SerializeField] private GameObject deadPanel = null;
    [SerializeField] private Text ammoText = null;

    [SerializeField] private Image healthSlider = null;
    [SerializeField] private TMP_Text healthText = null;

    [SerializeField] private Image shieldSlider = null;
    [SerializeField] private TMP_Text shieldText = null;

    [SerializeField] private GameObject actionInfo = null;

    [SerializeField] private Animator fade = null;

    [HideInInspector] private GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void Update()
    {
        RefreshPlayerStats();
    }

    private void RefreshPlayerStats()
    {
        SetHealth(gm.player.dmgShield.health);
        SetShield(gm.player.dmgShield.shield);
        SetAmoText(gm.player.gun.gunAmmo, gm.player.gun.ammo);

        if (gm.player.dmgShield.health <= 0 && healthShieldInfoPanel.activeSelf)
            Dead();

    }

    public void SetAmoText(int ammo, int loaderAmmo)
    {
        ammoText.text = ammo+" / "+loaderAmmo;
    }

    public void SetActiveGunInfo()
    {
        gunInfoPanel.SetActive(true);
    }

    public void SetHealth(int amount)
    {
        healthText.text = "" + amount;
        healthSlider.fillAmount = (amount + 0.0f) / 100;
    }

    public void SetShield(int amount)
    {
        shieldText.text = "" + amount;
        shieldSlider.fillAmount = (amount+0.0f) / 100;
    }

    public void Dead()
    {

        healthShieldInfoPanel.SetActive(false);
        gunInfoPanel.SetActive(false);
        deadPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        Invoke("Pause", .5f);

    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    public void Revive()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

        ChangeFade(); //Black

        healthShieldInfoPanel.SetActive(true);
        deadPanel.SetActive(false);
        if (gm.player.haveGun)
            gunInfoPanel.SetActive(false);

        gm.Revive();

    }

    public void ChangeFade()
    {
        fade.SetTrigger("Change");
    }
    

    public void SetActionButton(bool act)
    {
        actionInfo.SetActive(act);
    }

}
