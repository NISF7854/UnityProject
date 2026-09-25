using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdolState : PlayerGroundedState
{
    public PlayerIdolState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
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
        //Debug.Log("Wall Idol is running");
        player.Move(xInput);

        if(rb.velocity.x !=0)
        {
            machine.ChangeState(player.moveState);
        }
        
    }

}
