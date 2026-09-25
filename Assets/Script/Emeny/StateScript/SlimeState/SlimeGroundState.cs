using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGroundState : EnemyState
{
    public Enemy_Slime slime;

    public SlimeGroundState(Enemy baseenemy,Enemy_Slime slime,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.slime = slime;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
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
        //前方有人切换为撞击姿态
        if(slime.IsPlayerDetected(slime.sightDistance))
        {
            slime.machine.ChangeState(slime.clashState);
        }

    }
}
