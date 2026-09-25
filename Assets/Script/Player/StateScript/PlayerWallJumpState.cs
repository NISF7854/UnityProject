using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    { }
    

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.15f;
        player.rb.velocity = new Vector2(-player.facingDir*10,player.jumpForce);
        player.Filp();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer > 0)
        {
            stateTimer -= Time.deltaTime;
        }
        if ( stateTimer <=0)
        {
            machine.ChangeState(player.airState);
        }

        if(player.isWallDetected && !player.isGrounded)
        {
            machine.ChangeState(player.wallSlideState);
        }

        if(player.isGrounded)
        {
            
            machine.ChangeState(player.idolState);

        }
    }
}
