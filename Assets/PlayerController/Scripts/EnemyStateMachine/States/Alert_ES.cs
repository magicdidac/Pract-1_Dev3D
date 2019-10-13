using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert_ES : AState
{
    public Alert_ES(EnemyStateMachine self) : base(self)
    {

    }

    protected  override void DoStart()
    {
        Debug.Log(self.name + " changed state to " + this.GetType(), self.gameObject);
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
        if (self.recievedCritical)
            return new Hit_ES(self, this);

        return null;

    }
}
