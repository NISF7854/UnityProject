using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        player.playerAudio.PlaySFX(10);
        //player.skill.clone.CreateClone(player.transform);
        stateTimer = player.dashDuration;
        base.Enter();
        //冲刺时进入无敌
        player.isInvincible = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.dashTimer = player.dashCD;
        //退出无敌
        player.isInvincible = false;
    }

    public override void Update()
    {
        base.Update();
        player.Dash();
        stateTimer -= Time.deltaTime;
        if(stateTimer < 0)
        {
            machine.ChangeState(player.idolState);
        }
        if(!player.isGrounded&&player.isWallDetected)
        {
            machine.ChangeState(player.wallSlideState);
        }
    }
}
