using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerBlackHoleState : PlayerState
{
    float x;
    float y;


    public PlayerBlackHoleState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        x = player.transform.position.x;
        y = player.transform.position.y;

        player.transform.position = new Vector2(x, y + 2.5f);
        SkillManager.instance.blackhole.CreatBlackHole();
    }

    public override void Exit()
    {
        base.Exit();
        player.SetZoreVelocity();
        
    }

    public override void Update()
    {
        base.Update();
        player.transform.position = new Vector2(x, y+2.5f);
    }
}
