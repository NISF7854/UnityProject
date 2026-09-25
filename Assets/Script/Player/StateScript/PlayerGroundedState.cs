using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(!player.isGrounded)
        {
            machine.ChangeState(player.airState);
        }
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
        //Debug.Log("Wall Grounded is running");
        //检测脚离开地面
        if (!player.isGrounded&&rb.velocity.y>=0)
        {
            
        }
        else if (!player.isGrounded && rb.velocity.y < 0)
        {
            machine.ChangeState(player.airState);
        }
        //跳跃
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.K)) 
        {
            machine.ChangeState(player.jumpState);
        }
        //冲刺技能
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (player.dashTimer > 0)
            {
                return;
            }
            machine.ChangeState(player.dashState);
        }
        //攻击
        if(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.J))
        {
            machine.ChangeState(player.primaryAttackState);
            return;
        }
        //格挡
        if (Input.GetKey(KeyCode.F))
        {
            if(player.parryTimer>0)
            {
                return;
            }
            machine.ChangeState(player.counterAttackState);
            return;
        }
        //瞄准
        if(Input.GetKey(KeyCode.Q)&&!player.sword)
        {
            machine.ChangeState(player.aimSwordState);
        }
        //收剑
        if(Input.GetKey(KeyCode.Q)&&player.sword) 
        {
            player.sword.GetComponent<SkillSwordController>().ReturnSword();
        }
        //黑洞技能
        if(Input.GetKey(KeyCode.R))
        {
            machine.ChangeState(player.blackHoleState);
        }
    }
}