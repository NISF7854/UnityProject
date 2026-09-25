using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    public Enemy_Skeleton skeleton;
    public SkeletonAttackState(Enemy baseenemy,Enemy_Skeleton enemy ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        skeleton = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        skeleton.SetZoreVelocity();
        skeleton.lastAttackTime = Time.time;
        skeleton.enemyAudio.PlaySFX(1);
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.enemyAudio.PlaySFX(0);
    }

    public override void Update()
    {
        base.Update();
        

        if(triggerCalled) 
        {
            stateMachine.ChangeState(skeleton.battleState);
        }
    }
}
