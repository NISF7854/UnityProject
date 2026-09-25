using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //重置二段跳次数
        player.multiJumpNum = 1;

    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(0, rb.velocity.y * 0.5f);
        //脱离墙面
        if (xInput!=0&&xInput!=player.facingDir)
        {
            machine.ChangeState(player.idolState); 
        }
        if (player.isGrounded)
        {
            machine.ChangeState(player.idolState);
        }
        if(!player.isWallDetected)
        {
            machine.ChangeState(player.idolState);
        }
        //跳离墙面
        if(Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.K)) 
        {
            player.playerAudio.PlaySFX(Random.Range(7, 10));
            machine.ChangeState(player.wallJumpState);
            return;
        }

        //
     
    }
}
