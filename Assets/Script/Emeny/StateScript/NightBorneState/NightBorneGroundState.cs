using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneGroundState : EnemyState
{
    Enemy_NightBorne ntb;

    public NightBorneGroundState(Enemy baseenemy,Enemy_NightBorne ntb ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.ntb = ntb;
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
        if (ntb.IsPlayerDetected(ntb.sightDistance) || ntb.IsPlayerDetected(-ntb.rearDistance))
        {
            Debug.Log("battle");
            stateMachine.ChangeState(ntb.battleState);
        }

    }
}
