using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneBattleState : EnemyState
{
    Enemy_NightBorne ntb;
    public Transform playerTran;
    public NightBorneBattleState(Enemy baseenemy, Enemy_NightBorne ntb, EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.ntb = ntb;
    }

    public override void Enter()
    {
        base.Enter();
        playerTran = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
       
        //×·»÷Íæ¼Ò
        if (playerTran.position.x > ntb.transform.position.x + 0.2f)
        {
            ntb.SetVelocity(ntb.moveSpeed * 4.0f, ntb.rb.velocity.y);
        }
        else if(playerTran.position.x < ntb.transform.position.x - 0.2f)
        {
            ntb.SetVelocity(-ntb.moveSpeed * 4.0f, ntb.rb.velocity.y);
        }
        //¹¥»÷Íæ¼Ò
        if (ntb.IsPlayerDetected(ntb.sightDistance)) //Íæ¼ÒÍÑÀëÊÓÒ°½«ÍÑÀëÕ½¶·
        {
            stateTimer = ntb.battleTime;
            if (ntb.IsPlayerDetected(ntb.sightDistance).distance <= ntb.attackDistance)
            {
                
                
                stateMachine.ChangeState(ntb.attackState);
                

            }
        }
        else//Í£Ö¹×·»÷
        {
            if (stateTimer < 0)
            {
                Debug.Log("Exit");
                stateMachine.ChangeState(ntb.idleState);
            }
        }

        if(!ntb.isGrounded)
        {
            ntb.Filp();
            ntb.SetZoreVelocity();
            stateMachine.ChangeState(ntb.idleState);
        }
    }
}
