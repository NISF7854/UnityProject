using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;
    [Header(" Move Info")]
    public float moveSpeed;
    public float defaultMoveSpeed;
    public float idleTime;
    public float battleTime;
    [Header(" Attack Info")]
    public float sightDistance;
    public float attackDistance;
    public float rearDistance;
    public float retreatDistance;

    public float attackClamdown;
    public float attackTimer;
    [Header(" Stunned Info")]
    public float stunDuration;
    public Vector2 stunDirection;
    public bool canBeStunned;
    [SerializeField] protected GameObject counterImage;

    public bool isDead = false;

    [HideInInspector] public float lastAttackTime;

    //音效
    public EnemyAudio enemyAudio;


    //状态机
    public EnemyStateMachine machine {  get; private set; }

    public EnemyStatistic statistic { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        machine = new EnemyStateMachine();
        statistic = GetComponent<EnemyStatistic>();
    }
    protected override void Start()
    {
        base.Start();
        defaultMoveSpeed = moveSpeed;
        enemyAudio = GetComponentInChildren<EnemyAudio>();
        moveSpeed = statistic.speed.GetValue();
    }

    protected override void Update()
    {
        base.Update();
        //调用状态机
        machine.Update();

        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }
    public virtual void FreezeTime(bool beFroze)
    {
        if(beFroze)
        {
            moveSpeed = 0;
            ani.speed = 0;
        }
        if(!beFroze)
        {
            moveSpeed = defaultMoveSpeed;
            ani.speed = 1;
        }
    }

    public virtual IEnumerator FreezeTimeFor(float value)
    {
        FreezeTime(true);

        yield return new WaitForSeconds(value);

        FreezeTime(false);
    }




    public virtual void OpenCounterAttackWindow()
    {
        canBeStunned = true;
        counterImage.SetActive(true);
    }
    public virtual void CloseCounterAttackWindow()
    {
        canBeStunned = false;
        counterImage.SetActive(false);
    }
    public virtual bool CheckStunned()
    {
        if(canBeStunned)
        {
            CloseCounterAttackWindow();
            return true;
        }
        return false;
    }

    public virtual bool CanAttack()
    {
        return (Time.time - lastAttackTime) > attackClamdown;

    }

    //巡视范围
    public virtual RaycastHit2D IsPlayerDetected(float value)
    {
        return Physics2D.Raycast(wallCheck.transform.position, Vector2.right * facingDir, value, whatIsPlayer);

    }
    //销毁该单位实体
    public void DestoryThis()
    {
        Destroy(gameObject);
    }
    //被眩晕
    public virtual void BeStunned(Vector2 _attacker,float _stateTime,Vector2 _direction)
    {
        stunDuration = _stateTime;
        stunDirection = _direction;
        if(_attacker.x > transform.position.x)
        {
            rb.velocity = new Vector2(-stunDirection.x, stunDirection.y);
        }
        else
        {
            rb.velocity = new Vector2(stunDirection.x, stunDirection.y);
        }
        
    }
    //亡语
    public virtual void DeathRattle()
    {

    }
}
