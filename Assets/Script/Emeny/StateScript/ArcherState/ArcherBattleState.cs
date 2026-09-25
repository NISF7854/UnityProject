using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBattleState : EnemyState
{
    public Enemy_Archer archer;
    Player player;
    Transform playerTran;

    public ArcherBattleState(Enemy baseenemy,Enemy_Archer archer ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.archer = archer;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player;
        playerTran = player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        


        stateTimer -= Time.deltaTime;
        //×·»÷Íæ¼Ò
        if (playerTran.position.x > archer.transform.position.x)
        {
            
            
                archer.SetVelocity(archer.moveSpeed * 1.5f, archer.rb.velocity.y);
            
            
        }
        else
        {
           
            
                archer.SetVelocity(-archer.moveSpeed * 1.5f, archer.rb.velocity.y);
            
            
        }
        
        

        //¹¥»÷Íæ¼Ò
        if (archer.IsPlayerDetected(archer.sightDistance)) //Íæ¼ÒÍÑÀëÊÓÒ°½«ÍÑÀëÕ½¶·
        {
            stateTimer = archer.battleTime;
            if (archer.IsPlayerDetected(archer.sightDistance).distance <= archer.attackDistance)
            {
                archer.SetZoreVelocity();
                //¹¥»÷ÀäÈ´
                if(archer.attackTimer > 0)
                {
                    return;
                }

                if (archer.CanAttack())
                {
                    stateMachine.ChangeState(archer.aimState);
                }

            }
        }
        else//Í£Ö¹×·»÷
        {
            if (stateTimer < 0)
            {
                stateMachine.ChangeState(archer.idleState);
            }
        }

        //Åöµ½Ç½»òÐüÑÂÍ£Ö¹×·»÷
        if(!archer.isGrounded || archer.isWallDetected)
        {
            archer.Filp();
            stateMachine.ChangeState(archer.moveState);
        }

    }
}
