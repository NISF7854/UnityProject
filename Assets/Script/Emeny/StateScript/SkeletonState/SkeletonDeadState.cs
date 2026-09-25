using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkeletonDeadState : EnemyState
{
    Enemy_Skeleton skeleton;

    SpriteRenderer sr;

    float deadTime;
    
    public SkeletonDeadState(Enemy baseenemy,Enemy_Skeleton enemy ,EnemyStateMachine stateMachine, string name) : base(baseenemy, stateMachine, name)
    {
        skeleton = enemy;

    }

    public override void Enter()
    {
        base.Enter();


        deadTime = Time.time;
        sr = skeleton.GetComponentInChildren<SpriteRenderer>();
        HealthUIController healthUI = skeleton.GetComponentInChildren<HealthUIController>();
        healthUI.DestroyThis();
        skeleton.SetZoreVelocity();
        //¹Ø±ÕÅö×²Ìå»ý
        skeleton.GetComponent<CapsuleCollider2D>().enabled = false;
        skeleton.rb.gravityScale = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        sr.color = new Color(1, 1, 1, 1 - ((Time.time - deadTime) / 2.5f));
        if(sr.color.a <= 0 ) 
        {
            skeleton.DestoryThis();
        }

    }
}
