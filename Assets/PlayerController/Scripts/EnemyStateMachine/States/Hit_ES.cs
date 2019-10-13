using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_ES : AState
{
    private AState oldState;

    public Hit_ES(EnemyStateMachine self, AState oldState) : base(self)
    {
        this.oldState = oldState;
        self.recievedCritical = false;
        self.recievedDamage = false;
    }

    protected  override void DoStart()
    {
        
    }



    public override void DoUpdate()
    {
        
    }

    public override void DoFixedUpdate()
    {
        if (Time.time - startTime > 1)
        {
            switch (oldState)
            {

                case Alert_ES t:
                    self.currentState = new Alert_ES(self);
                    break;
                case Attack_ES t:
                    self.currentState = new Attack_ES(self);
                    break;
                case Chase_ES t:
                    self.currentState = new Chase_ES(self);
                    break;
                case Idle_ES t:
                    self.currentState = new Idle_ES(self);
                    break;
                case Patrol_ES t:
                    self.currentState = new Alert_ES(self);
                    break;

            }
        }
    }

    public override void DoExit()
    {
        
    }

    public override AState ChangeState()
    {
        return null;
    }

}
