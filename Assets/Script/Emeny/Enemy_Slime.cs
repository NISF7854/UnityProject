using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slime : Enemy
{
  

    //状态
    public SlimeGroundState groundState;
    public SlimeIdleState idleState;
    public SlimeMoveState moveState;
    public SlimeClashState clashState;
    public bool isClashing = false;

    public SlimeStunnedState stunnedState;
    public SlimeDeadState deadState;
    protected override void Awake()
    {
        base.Awake();
        //修改初始怪物面向方向
        facingDir = -1;
        isFacingRight = false;

        //初始化状态
        idleState = new SlimeIdleState(this, this,machine, "Idle");
        moveState = new SlimeMoveState(this, this, machine, "Move");
        clashState = new SlimeClashState(this, this, machine, "Clash");
        stunnedState = new SlimeStunnedState(this, this, machine, "Stunned");
        deadState = new SlimeDeadState(this, this, machine, "Dead");
    }

    protected override void Start()
    {
        base.Start();

        machine.Initialize(idleState);

        //攻击碰撞与攻击检测半径保持一致
        attackCheck.GetComponent<CapsuleCollider2D>().size = new Vector2(attackRadius, attackRadius);
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
    }

    //被眩晕
    public override void BeStunned(Vector2 _attacker, float _stateTime, Vector2 _direction)
    {
        base.BeStunned(_attacker, _stateTime, _direction);
        machine.ChangeState(stunnedState);
    }



}
