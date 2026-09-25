using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAttackState : EnemyState
{
    Enemy_NightBorne ntb;

    public NightBorneAttackState(Enemy baseenemy, Enemy_NightBorne ntb, EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.ntb = ntb;
    }

    public override void Enter()
    {
        base.Enter();
        ntb.SetZoreVelocity();
        ntb.unstoppable = true;
    }

    public override void Exit()
    {
        base.Exit();
        ntb.unstoppable = false;
    }

    public override void Update()
    {
        base.Update();
    }
}
