using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAimState : EnemyState
{
    Enemy_Archer archer;

    public ArcherAimState(Enemy baseenemy,Enemy_Archer archer ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.archer = archer;
    }

    public override void Enter()
    {
        base.Enter();
        archer.SetZoreVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
