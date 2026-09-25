using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArcherGroundState : EnemyState
{
    protected Enemy_Archer archer;
    public ArcherGroundState(Enemy baseenemy,Enemy_Archer archer ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.archer = archer;
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
        //玩家距离过近时后撤
        if(archer.IsPlayerDetected(archer.retreatDistance))
        {
            if(!archer.isWallDetected && archer.isGrounded)
            {
                Debug.Log("1");
                if (archer.retreatTimer <= 0)
                {
                    Debug.Log("2");
                    stateMachine.ChangeState(archer.dashState);
                    return;
                }
            }

            
            
        }

        //追击玩家
        if(archer.IsPlayerDetected(archer.sightDistance) || archer.IsPlayerDetected(-archer.rearDistance))
        {
            if(archer.isGrounded)
                stateMachine.ChangeState(archer.battleState);
        }

    }
}
