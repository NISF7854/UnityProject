using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStunnedState : EnemyState
{
    Enemy_Slime slime;
    private Player player;

    public SlimeStunnedState(Enemy baseenemy,Enemy_Slime slime ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.slime = slime;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player;
        stateTimer = slime.stunDuration;
        
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
            slime.SetZoreVelocity();
            stateMachine.ChangeState(slime.idleState);
        }
    }
}
