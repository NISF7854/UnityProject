using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimSwordState : PlayerState
{
    public PlayerAimSwordState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.skill.sword.DotsActive(true);
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetZoreVelocity();
        if (Input.GetKeyUp(KeyCode.Q))
        {
            machine.ChangeState(player.idolState);
        }
    }
}
