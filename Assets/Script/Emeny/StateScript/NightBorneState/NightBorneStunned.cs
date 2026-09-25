using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneStunned : EnemyState
{
    Enemy_NightBorne ntb;

    public NightBorneStunned(Enemy baseenemy, Enemy_NightBorne ntb, EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.ntb = ntb;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        stateTimer = ntb.stunDuration;
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;
        if (stateTimer < 0)
        {
            ntb.SetZoreVelocity();
            stateMachine.ChangeState(ntb.idleState);
        }
    }
}
