using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_NightBorne : Enemy
{

    public NightBorneIdleState idleState;
    public NightBorneMoveState moveState;
    public NightBorneAttackState attackState;
    public NightBorneBattleState battleState;
    public NightBorneDeadState deadState;
    public NightBorneStunned stunnedState;

    public bool unstoppable = false; 


    protected override void Awake()
    {
        base.Awake();

        idleState = new NightBorneIdleState(this, this, machine, "Idle");
        moveState = new NightBorneMoveState(this, this, machine, "Move");
        attackState = new NightBorneAttackState(this, this, machine, "Attack");
        battleState = new NightBorneBattleState(this, this, machine, "Move");
        deadState = new NightBorneDeadState(this, this, machine, "Dead");
        stunnedState = new NightBorneStunned(this, this, machine, "Stunned");

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

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y - 0.1f), new Vector3
            (wallCheck.transform.position.x + sightDistance * facingDir, wallCheck.transform.position.y - 0.1f));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y - 0.2f), new Vector3
            (wallCheck.transform.position.x + attackDistance * facingDir, wallCheck.transform.position.y - 0.2f));
        //身后视野
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y - .1f), new Vector3
            (wallCheck.transform.position.x + rearDistance * -facingDir, wallCheck.transform.position.y - .1f));
    }
    public override void BeStunned(Vector2 _attacker, float _stateTime, Vector2 _direction)
    {
        base.BeStunned(_attacker, _stateTime, _direction);
        machine.ChangeState(stunnedState);
    }

    //亡语
    public override void DeathRattle()
    {
        base.DeathRattle();
        //自爆
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 4.0f);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                Player player = hit.GetComponent<Player>();
                statistic.DoDamage(player.statistic);
                
            }
        }
    }
}
