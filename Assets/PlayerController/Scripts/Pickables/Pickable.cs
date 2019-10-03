using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    [SerializeField] public bool getActionButton = false;
    [SerializeField] protected bool getPlayerAbove = true;

    [HideInInspector] protected GameManager gm;

    protected virtual void Start()
    {
        this.tag = "Pickable";
        gm = GameManager.instance;
    }

    protected abstract void GetPickable();

    public void GetWithActionButton()
    {
        if (getActionButton)
            GetPickable();
    }

    public void GetWithTrigger()
    {
        if (getPlayerAbove)
            GetPickable();
    }

}
