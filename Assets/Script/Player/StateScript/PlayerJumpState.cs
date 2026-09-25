using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    

    public PlayerJumpState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Jump();
        player.playerAudio.PlaySFX(Random.Range(7, 10));

        //Debug.Log("1");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("Wall Jump is running");
        player.Move(xInput);

        //如果y轴速度下降，转换到AirState
        if(rb.velocity.y<=0)
        {
            machine.ChangeState(player.airState);
        }
        //空中dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (player.dashTimer > 0)
            {
                return;
            }
            machine.ChangeState(player.dashState);
        }

    }

}
