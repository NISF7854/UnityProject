using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Machine machine, Player player,  string animBoolName) : base(machine, player,  animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        player.playerAudio.PlaySFX(6);
    }

    public override void Exit() 
    { 
        base.Exit();
        player.playerAudio.StopSFX(6);
    }
    public override void Update() 
    { 
        base.Update(); 
        player.Move(xInput);
        //×ª»»ÖÁ ´ý»ú ×´Ì¬
        if(rb.velocity.x==0)
        {
            machine.ChangeState(player.idolState);
        }
    }
}
