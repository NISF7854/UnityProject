using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy baseEnemy;

    protected bool triggerCalled;
    protected float stateTimer;
    private string animationName;

    public EnemyState(Enemy baseenemy,EnemyStateMachine stateMachine,string name)
    {
        this.baseEnemy = baseenemy;
        this.stateMachine = stateMachine;
        this.animationName = name;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        baseEnemy.ani.SetBool(animationName, true);
    }
    public virtual void Exit() 
    {
        baseEnemy.ani.SetBool(animationName, false);
    }
    public virtual void Update()
    {
        if (stateTimer >= 0)
        {
            stateTimer -= Time.deltaTime;

        }
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
