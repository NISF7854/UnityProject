using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    public SkeletonIdleState idleState;
    public SkeletonMoveState moveState;
    public SkeletonBattleState battleState ;
    public SkeletonAttackState attackState;
    public SkeletonStunnedState stunnedState;
    public SkeletonDeadState deadState;

   
    protected override void Awake()
    {
        base.Awake();
        

        idleState = new SkeletonIdleState(this, this, machine, "Idle");
        moveState = new SkeletonMoveState(this, this, machine, "Move");
        battleState = new SkeletonBattleState(this, this, machine, "Move");
        attackState = new SkeletonAttackState(this, this, machine, "Attack");
        stunnedState = new SkeletonStunnedState(this, this, machine, "Stunned");
        deadState = new SkeletonDeadState(this, this, machine, "Dead");
    }

    protected override void Start()
    {
        base.Start();
        machine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
       
    }
    public override bool CheckStunned()
    {
        if(base.CheckStunned())
        {
            machine.ChangeState(stunnedState);
            return true;
        }
        return false;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y-0.1f), new Vector3
            (wallCheck.transform.position.x + sightDistance * facingDir, wallCheck.transform.position.y-0.1f));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y - 0.2f), new Vector3
            (wallCheck.transform.position.x + attackDistance * facingDir, wallCheck.transform.position.y - 0.2f));
    }

    public override void BeStunned(Vector2 _attacker, float _stateTime, Vector2 _direction)
    {
        base.BeStunned(_attacker, _stateTime, _direction);
        machine.ChangeState(stunnedState);
    }
}
