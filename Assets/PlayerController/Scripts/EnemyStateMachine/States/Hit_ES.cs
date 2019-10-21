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
        self.agent.isStopped = true;
        self.agent.ResetPath();
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
        if (self.damager.health <= 0)
            return new Die_ES(self);

        if (Time.time - startTime > .5f)
        {
            switch (oldState)
            {

                case Alert_ES t:
                    return new Alert_ES(self);
                case Attack_ES t:
                    return new Attack_ES(self);
                case Chase_ES t:
                    return new Chase_ES(self);
                case Idle_ES t:
                    return new Idle_ES(self);
                case Patrol_ES t:
                    return new Alert_ES(self);

            }
        }

        return null;
    }

}
