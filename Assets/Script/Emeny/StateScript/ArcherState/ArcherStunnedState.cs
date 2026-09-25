using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStunnedState : EnemyState
{
    Enemy_Archer archer;
    public ArcherStunnedState(Enemy baseenemy,Enemy_Archer _archer ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        archer = _archer;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = archer.stunDuration;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;

        if(stateTimer < 0 )
        {
            archer.SetZoreVelocity();
            archer.machine.ChangeState(archer.idleState);
        }

    }
}
