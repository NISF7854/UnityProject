using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDeadState : EnemyState
{
    Enemy_Slime slime;
    SpriteRenderer sr;
    float deadTime;

    public SlimeDeadState(Enemy baseenemy,Enemy_Slime slime ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.slime = slime;
    }

    public override void Enter()
    {
        base.Enter();

        deadTime = Time.time;
        sr = slime.GetComponentInChildren<SpriteRenderer>();
        HealthUIController healthUI = slime.GetComponentInChildren<HealthUIController>();
        healthUI.DestroyThis();
        slime.SetZoreVelocity();
        //¹Ø±ÕÅö×²Ìå»ý
        slime.GetComponent<CapsuleCollider2D>().enabled = false;
        slime.rb.gravityScale = 0;


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        sr.color = new Color(1, 1, 1, 1 - ((Time.time - deadTime) / 2.5f));
        if (sr.color.a <= 0)
        {
            slime.DestoryThis();
        }
    }
}
