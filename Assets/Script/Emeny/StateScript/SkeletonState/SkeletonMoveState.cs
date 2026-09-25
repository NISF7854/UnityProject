using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundState
{
    public SkeletonMoveState(Enemy baseenemy, Enemy_Skeleton enemy, EnemyStateMachine stateMachine, string name) : base(baseenemy, enemy, stateMachine, name)
    {
    }

    public override void Enter()
    {
        skeleton.enemyAudio.PlaySFX(0);
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.enemyAudio.StopSFX(0);
    }

    public override void Update()
    {
        base.Update();

        //ÒÆ¶¯
        skeleton.rb.velocity = new Vector2(skeleton.moveSpeed * skeleton.facingDir, skeleton.rb.velocity.y);
        //µôÍ·
        if(skeleton.isWallDetected||!skeleton.isGrounded)
        {
            skeleton.Filp();
            skeleton.rb.velocity = new Vector2(0, skeleton.rb.velocity.y);
            //ÇÐ»»Îªidle×´Ì¬
            stateMachine.ChangeState(skeleton.idleState);
        }
    }
}
