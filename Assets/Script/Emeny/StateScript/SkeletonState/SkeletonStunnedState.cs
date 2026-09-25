using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    private Enemy_Skeleton skeleton;
    private Player player;

    public SkeletonStunnedState(Enemy baseenemy,Enemy_Skeleton enemy ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        skeleton = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        skeleton.CloseCounterAttackWindow();
        player = PlayerManager.instance.player;

        stateTimer = skeleton.stunDuration;
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;
        if(stateTimer < 0)
        {
            skeleton.SetZoreVelocity();
            stateMachine.ChangeState(skeleton.idleState);
        }

       
    }
}
