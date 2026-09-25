using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundState : EnemyState
{
    protected Enemy_Skeleton skeleton;

    
    //protected Player player;
    public SkeletonGroundState(Enemy baseenemy,Enemy_Skeleton enemy ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        skeleton = enemy;      
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
        //转换到battleState(检测到前方有人或身后有人)
        if(skeleton.IsPlayerDetected(skeleton.sightDistance)||Vector2.Distance(PlayerManager.instance.player.transform.position,skeleton.transform.position)<1.8f)
        {
            stateMachine.ChangeState(skeleton.battleState);
        }
    }
}
