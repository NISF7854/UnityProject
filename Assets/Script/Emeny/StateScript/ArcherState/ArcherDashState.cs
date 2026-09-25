using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDashState : EnemyState
{

    Enemy_Archer archer;

    public ArcherDashState(Enemy baseenemy,Enemy_Archer _archer ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        archer = _archer;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.67f;

        archer.SetVelocity(-archer.facingDir * 15.0f, archer.rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();


        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            archer.retreatTimer = archer.retreatCD;
            stateMachine.ChangeState(archer.idleState);
            Debug.Log("3");
            archer.Filp();
        }
        //Óöµ½Ç½±Ú»òÕß ÐüÑÂÁ¢¿ÌÍ£Ö¹
        if(archer.isWallDetected || !archer.isGrounded)
        {
            archer.retreatTimer = archer.retreatCD;
            archer.SetZoreVelocity();
            stateMachine.ChangeState(archer.idleState);
            Debug.Log("4");
            archer.Filp();
        }



    }
}
