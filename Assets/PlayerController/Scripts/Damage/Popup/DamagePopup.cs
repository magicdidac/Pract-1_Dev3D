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

    private void OnEnable()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();

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
        }
        catch { Destroy(gameObject); }
    }

}
