using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroDeadState : EnemyState
{
    Enemy_Necro necro;
    
    SpriteRenderer sr;
    float deadTime;

    public NecroDeadState(Enemy baseenemy,Enemy_Necro necro ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        this.necro = necro;
    }

    public override void Enter()
    {
        base.Enter();
        deadTime = Time.time;
        sr = necro.GetComponentInChildren<SpriteRenderer>();
        HealthUIController healthUI = necro.GetComponentInChildren<HealthUIController>();
        healthUI.DestroyThis();
        necro.SetZoreVelocity();
        //¹Ø±ÕÅö×²Ìå»ý
        necro.GetComponent<CapsuleCollider2D>().enabled = false;
        necro.rb.gravityScale = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        base.Update();
        sr.color = new Color(1, 1, 1, 1 - ((Time.time - deadTime) / 2.5f));
        if (sr.color.a <= 0)
        {
            necro.DestoryThis();
        }
    }
}
