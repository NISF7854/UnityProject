using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletonGroundState
{
    public SkeletonIdleState(Enemy baseenemy, Enemy_Skeleton enemy, EnemyStateMachine stateMachine, string name) : base(baseenemy, enemy, stateMachine, name)
    {
 
    }

 
    public override void Enter()
    {
        base.Enter();
        stateTimer = skeleton.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;
        if (stateTimer < 0) 
        {
            stateMachine.ChangeState(skeleton.moveState);
        }
    }
}
