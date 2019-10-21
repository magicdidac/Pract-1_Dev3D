using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [HideInInspector] private Animator anim;
    [HideInInspector] private TMP_Text damageText;

    [HideInInspector] public Vector3 target;

    [HideInInspector] public Vector3 offset;

    [HideInInspector] private Transform player;

    private void OnEnable()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        player = GameManager.instance.player.transform;

        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length-.01f);
        damageText = anim.GetComponent<TMP_Text>();
    }

    public void SetText(string text)
    {
        damageText.text = text;
    }

    public void Update()
    {
        try
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(target + offset);
            transform.position = screenPosition;
            transform.localScale = Vector3.one * (((.5f - 1) / 15) * Vector3.Distance(target, player.position) + 1);
        }
        catch { Destroy(gameObject); }
    }

}
