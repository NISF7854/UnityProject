using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneIdleState : NightBorneGroundState
{
    Enemy_NightBorne ntb;

    public NightBorneIdleState(Enemy baseenemy, Enemy_NightBorne ntb, EnemyStateMachine stateMachine, string name) : base(baseenemy,ntb, stateMachine, name)
    {
        this.ntb = ntb;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = ntb.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer <= 0)
        {
            stateMachine.ChangeState(ntb.moveState);
        }


    }
}
