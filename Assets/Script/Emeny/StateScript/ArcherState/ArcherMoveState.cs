using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMoveState : ArcherGroundState
{
    public ArcherMoveState(Enemy baseenemy, Enemy_Archer archer, EnemyStateMachine stateMachine, string name) : base(baseenemy, archer, stateMachine, name)
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
        archer.SetVelocity(archer.facingDir * archer.moveSpeed, archer.rb.velocity.y);
        //µôÍ·
        if (archer.isWallDetected || !archer.isGrounded)
        {
            archer.Filp();
            archer.rb.velocity = new Vector2(0, archer.rb.velocity.y);
            //ÇÐ»»Îªidle×´Ì¬
            stateMachine.ChangeState(archer.idleState);
        }

    }
}
