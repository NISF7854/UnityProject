using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherIdleState : ArcherGroundState
{
    public ArcherIdleState(Enemy baseenemy, Enemy_Archer archer, EnemyStateMachine stateMachine, string name) : base(baseenemy, archer, stateMachine, name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = archer.idleTime;
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
            archer.machine.ChangeState(archer.moveState);
        }
    }
}
