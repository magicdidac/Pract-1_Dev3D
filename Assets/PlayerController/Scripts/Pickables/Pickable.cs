using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    [SerializeField] public bool getActionButton = false;
    [SerializeField] protected bool getPlayerAbove = true;
    [HideInInspector] protected bool goToPlayer = false;
    [SerializeField] private float moveSpeed = 1;
    [HideInInspector] protected Collider triggerCol = null;

    [HideInInspector] protected GameManager gm;

    protected virtual void Start()
    {
        this.tag = "Pickable";
        triggerCol = GetComponent<Collider>();
        gm = GameManager.instance;
    }

    private void GetPickable()
    {
        goToPlayer = true;
        triggerCol.enabled = false;
    }

    protected abstract void NowGetPickable();

    public abstract bool CanTakeIt();

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

    private void FixedUpdate()
    {
        if (goToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, gm.player.transform.position, moveSpeed);

            if (transform.position == gm.player.transform.position)
                NowGetPickable();
        }
    }


}
