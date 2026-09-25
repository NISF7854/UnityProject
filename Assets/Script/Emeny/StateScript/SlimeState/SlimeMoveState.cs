using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveState : SlimeGroundState
{
    public SlimeMoveState(Enemy baseenemy,Enemy_Slime slime ,EnemyStateMachine stateMachine, string name) : base(baseenemy,slime ,stateMachine, name)
    {
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
        //ÒÆ¶¯
        slime.rb.velocity = new Vector2(slime.moveSpeed * slime.facingDir, slime.rb.velocity.y);
        //µôÍ·
        if(slime.isWallDetected || !slime.isGrounded) 
        {
            slime.Filp();
            slime.SetZoreVelocity();
            slime.machine.ChangeState(slime.idleState);

        }


    }
}
