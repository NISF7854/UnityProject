using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeClashState : EnemyState
{
    Enemy_Slime slime;

    public SlimeClashState(Enemy baseenemy,Enemy_Slime slime ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.slime = slime;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 4.0f;

        slime.isClashing = true;
    }

    public override void Exit()
    {
        base.Exit();

        slime.isClashing = false;
    }

    public override void Update()
    {
        base.Update();
        //³å×²
        slime.SetVelocity(slime.moveSpeed * 8.0f * slime.facingDir, slime.rb.velocity.y);
        stateTimer -= Time.deltaTime;

        if(!slime.isGrounded||slime.isWallDetected||stateTimer<=0)
        {
            slime.Filp();
            slime.SetZoreVelocity();
            
            slime.BeStunned(new Vector2(slime.transform.position.x + slime.facingDir, slime.transform.position.y),2.0f,slime.stunDirection);
            return;
        }
        
        
    }
}
