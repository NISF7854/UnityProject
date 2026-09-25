using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
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
        //Debug.Log("Wall Air is running");
        player.Move(xInput);

        //«–ªªµΩidol◊¥Ã¨
        if (player.isGrounded)
        {
            machine.ChangeState(player.idolState);
        }
        //≥Â¥Ã
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (player.dashTimer > 0)
            {
                return;
            }
            machine.ChangeState(player.dashState);
        }
        //ª¨«Ω
        if(player.isWallDetected&&!player.isGrounded&&player.wallSlideTimer<=0)
        {
            machine.ChangeState(player.wallSlideState);
        }
        //∂˛∂ŒÃ¯
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.K))
        {
            if(player.multiJumpNum > 0)
            {
                machine.ChangeState(player.jumpState);
                player.multiJumpNum = 0;
            }
            
        }
        //œ¬‘“
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            machine.ChangeState(player.fallingState);
        }
    }
}
