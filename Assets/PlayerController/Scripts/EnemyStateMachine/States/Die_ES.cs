using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_ES : AState
{
    public Die_ES(EnemyStateMachine self) : base(self)
    {
        Debug.Log(self.name + " changed state to " + this.GetType(), self.gameObject);
    }

    protected  override void DoStart()
    {
        
    }

    public override void DoUpdate()
    {
        
    }

    public override void DoFixedUpdate()
    {
        
    }

    public override void DoExit()
    {
        
    }

    public override AState ChangeState()
    {
        return null;
    }

}
