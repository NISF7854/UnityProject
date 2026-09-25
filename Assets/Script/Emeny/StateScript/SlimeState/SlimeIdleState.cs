using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : SlimeGroundState
{

    
    public SlimeIdleState(Enemy baseenemy,Enemy_Slime slime ,EnemyStateMachine stateMachine, string name) : base(baseenemy,slime ,stateMachine, name)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = slime.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        //idle×´Ì¬¼ÆÊ±Æ÷
        stateTimer -= Time.deltaTime;
        //ÇÐ»»MoveState
        if(stateTimer <= 0 )
        {
            stateMachine.ChangeState(slime.moveState);
        }

    }
}
