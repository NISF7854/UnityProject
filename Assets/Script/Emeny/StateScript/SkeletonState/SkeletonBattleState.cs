using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    public Enemy_Skeleton skeleton {  get; private set; }
    public Transform playerTran {  get; private set; }
    public SkeletonBattleState(Enemy baseenemy,Enemy_Skeleton enemy, EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        skeleton = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        playerTran = PlayerManager.instance.player.transform;

        skeleton.enemyAudio.PlaySFX(0);
    }

    public override void Exit()
    {
        base.Exit();
        //skeleton.SetZoreVelocity();

        skeleton.enemyAudio.StopSFX(0);
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;
        //◊∑ª˜ÕÊº“
        if(playerTran.position.x>skeleton.transform.position.x) 
        {
            skeleton.SetVelocity(skeleton.moveSpeed * 1.5f, skeleton.rb.velocity.y);
        }
        else
        {
            skeleton.SetVelocity(-skeleton.moveSpeed * 1.5f, skeleton.rb.velocity.y);
        }
        //π•ª˜ÕÊº“
        if(skeleton.IsPlayerDetected(skeleton.sightDistance)) //ÕÊº“Õ—¿Î ”“∞Ω´Õ—¿Î’Ω∂∑
        {
            stateTimer = skeleton.battleTime;
            if(skeleton.IsPlayerDetected(skeleton.sightDistance).distance<=skeleton.attackDistance)
            {
                if (skeleton.CanAttack()) 
                {
                    stateMachine.ChangeState(skeleton.attackState);
                }
                
            }
        }
        else//Õ£÷π◊∑ª˜
        {
            if(stateTimer<0)
            {
                stateMachine.ChangeState(skeleton.idleState);
            }
        }
        if (!skeleton.isGrounded)
        {
            skeleton.Filp();
            stateMachine.ChangeState(skeleton.idleState);
        }
    }
}
