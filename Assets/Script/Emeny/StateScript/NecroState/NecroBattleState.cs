using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroBattleState : EnemyState
{
    Enemy_Necro necro;


    public NecroBattleState(Enemy baseenemy,Enemy_Necro _necro ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
          necro = _necro;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = necro.attackClamdown;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer <= 0 && necro.isPlayerInRange)
        {
            necro.machine.ChangeState(necro.castingState);
        }
        if(necro.isPlayerInRange == false) 
        {
            necro.machine.ChangeState(necro.idleState);
        }


    }
}
