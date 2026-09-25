using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStunnedState : PlayerState

{
    public PlayerStunnedState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       
        stateTimer = 0.5f;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetZoreVelocity();
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;

        if(stateTimer < 0) 
        {
            machine.ChangeState(player.idolState);
        }
    }
}
