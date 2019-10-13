using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_ES : AState
{

    private Vector3 nextPost;

    public Patrol_ES(EnemyStateMachine self) : base(self)
    {
        nextPost = self.positions[self.posIndex];
        if (self.posIndex + 1 >= self.positions.Count)
            self.posIndex = 0;
        else
            self.posIndex++;
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
        self.transform.position = Vector3.MoveTowards(self.transform.position, nextPost, self.speed * Time.deltaTime);
    }

    public override void DoExit()
    {
        
    }

    public override AState ChangeState()
    {
        if (self.recievedCritical || self.recievedDamage)
            return new Hit_ES(self, this);

        if (self.listenPlayer)
        {
            self.listenPlayer = false;
            return new Alert_ES(self);
        }

        if (self.transform.position == nextPost)
            return new Idle_ES(self);

        return null;
    }
}
