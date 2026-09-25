using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDeadState : EnemyState
{

    Enemy_Archer archer;
    SpriteRenderer sr;
    float deadTime;
    public ArcherDeadState(Enemy baseenemy,Enemy_Archer archer ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.archer = archer;
    }

    public override void Enter()
    {
        base.Enter();
        deadTime = Time.time;
        sr = archer.GetComponentInChildren<SpriteRenderer>();
        HealthUIController healthUI = archer.GetComponentInChildren<HealthUIController>();
        healthUI.DestroyThis();
        archer.SetZoreVelocity();
        //¹Ø±ÕÅö×²Ìå»ý
        archer.GetComponent<CapsuleCollider2D>().enabled = false;
        archer.rb.gravityScale = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        sr.color = new Color(1, 1, 1, 1 - ((Time.time - deadTime) / 5.0f));
        if (sr.color.a <= 0)
        {
            archer.DestoryThis();
        }
    }
}
