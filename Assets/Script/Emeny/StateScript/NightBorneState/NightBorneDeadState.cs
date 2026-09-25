using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneDeadState : EnemyState
{
    Enemy_NightBorne ntb;
    SpriteRenderer sr;

    float deadTime;

    public NightBorneDeadState(Enemy baseenemy, Enemy_NightBorne ntb, EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.ntb = ntb;
    }

    public override void Enter()
    {
        base.Enter();
        deadTime = Time.time;
        sr = ntb.GetComponentInChildren<SpriteRenderer>();
        HealthUIController healthUI = ntb.GetComponentInChildren<HealthUIController>();
        healthUI.DestroyThis();
        ntb.SetZoreVelocity();
        //¹Ø±ÕÅö×²Ìå»ý
        ntb.GetComponent<CapsuleCollider2D>().enabled = false;
        ntb.rb.gravityScale = 0;
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
            ntb.DestoryThis();
        }
    }
}
