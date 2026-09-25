using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Archer : Enemy
{
    //◊¥Ã¨ª˙
    public ArcherIdleState idleState;
    public ArcherMoveState moveState;
    public ArcherBattleState battleState;
    public ArcherAimState aimState;
    public ArcherStunnedState stunnedState;
    public ArcherDeadState deadState;
    public ArcherDashState dashState;
    //≥∑ÕÀCD
    public float retreatCD = 3.0f;
    public float retreatTimer;

    protected override void Awake()
    {
        base.Awake();

        idleState = new ArcherIdleState(this,this,machine,"Idle");
        moveState = new ArcherMoveState(this, this, machine, "Move");
        battleState = new ArcherBattleState(this, this, machine, "Battle");
        aimState = new ArcherAimState(this, this, machine, "Aim");
        stunnedState = new ArcherStunnedState(this, this, machine, "Stunned");
        deadState = new ArcherDeadState(this, this, machine, "Dead");
        dashState = new ArcherDashState(this, this, machine, "Dash");
    }

    protected override void Start()
    {
        base.Start();
        machine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        ani.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

        if(retreatTimer >= 0)
            retreatTimer -= Time.deltaTime;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        // ”“∞
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y - 0.1f), new Vector3
            (wallCheck.transform.position.x + sightDistance * facingDir, wallCheck.transform.position.y - 0.1f));
        //π•ª˜∑∂Œß
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y - 0.2f), new Vector3
            (wallCheck.transform.position.x + attackDistance * facingDir, wallCheck.transform.position.y - 0.2f));
        //…Ì∫Û ”“∞
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y - .1f), new Vector3
            (wallCheck.transform.position.x + rearDistance * -facingDir, wallCheck.transform.position.y - .1f));
        //≥∑ÕÀæ‡¿Î
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(wallCheck.transform.position.x, wallCheck.transform.position.y - .3f), new Vector3
            (wallCheck.transform.position.x + retreatDistance * facingDir, wallCheck.transform.position.y - .3f));
    }


    public override void BeStunned(Vector2 _attacker, float _stateTime, Vector2 _direction)
    {
        base.BeStunned(_attacker, _stateTime, _direction);
        machine.ChangeState(stunnedState);
    }

}
