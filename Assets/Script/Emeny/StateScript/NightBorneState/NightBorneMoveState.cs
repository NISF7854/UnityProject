using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneMoveState : NightBorneGroundState
{
    Enemy_NightBorne ntb;

    public NightBorneMoveState(Enemy baseenemy, Enemy_NightBorne ntb, EnemyStateMachine stateMachine, string name) : base(baseenemy, ntb, stateMachine, name)
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
    }

    public override void Update()
    {
        base.Update();
        ntb.SetVelocity(ntb.facingDir * ntb.moveSpeed, ntb.rb.velocity.y);

        //µôÍ·
        if (ntb.isWallDetected || !ntb.isGrounded)
        {
            ntb.Filp();
            ntb.SetZoreVelocity();
            //ÇÐ»»Îªidle×´Ì¬
            stateMachine.ChangeState(ntb.idleState);
        }


    }
}
