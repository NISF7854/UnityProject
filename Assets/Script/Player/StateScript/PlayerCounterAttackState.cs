using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    public PlayerCounterAttackState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.counterAttackDuration;
        player.isParrying = true;

        player.ani.SetBool("SuccessfullyCounter", false);
    }

    public override void Exit()
    {
        player.isParrying = false;
        
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetZoreVelocity();
        stateTimer -= Time.deltaTime;

        if(stateTimer < 0)
        {
            machine.ChangeState(player.idolState);
            player.parryTimer = player.parryCD;
            return;
        }
        if(triggerCalled) 
        {
            machine.ChangeState(player.idolState);
            player.parryTimer = 0.15f;
            return;
        }
        
    }
}
