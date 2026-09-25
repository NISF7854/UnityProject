using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    public PlayerFallingState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {

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
        player.SetVelocity(0, -22f);

        //退出状态并对周围敌人造成伤害
        if(player.isGrounded)
        {
            player.machine.ChangeState(player.idolState);
        }
    }
}
