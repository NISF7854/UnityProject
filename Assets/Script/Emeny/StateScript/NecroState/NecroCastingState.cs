using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroCastingState : EnemyState
{
    Enemy_Necro necro;

    public NecroCastingState(Enemy baseenemy, Enemy_Necro _necro ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        necro = _necro;
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
    }
}
