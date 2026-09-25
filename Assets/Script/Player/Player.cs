using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public bool isBusy { private set ; get; }

    [Header("Attack Arr")]
    public Vector2[] attackArr;

    [Header("Info")]
    public float moveSpeed;
    public float jumpForce;
    public int multiJumpNum;

    public bool isMoving;
    public float x;
    public float y;

    public bool isDead = false;
    [Header("Dash Skill")]
    public float dashTimer=0f;
    [SerializeField] public float dashDuration = 0.7f;
    [SerializeField] private float dashSpeed = 10.0f;
    [SerializeField] public float dashCD = 2.0f;

    [Header("Attack")]
    //[SerializeField] private bool isAttacking = false;
    public int attackCombo = 0;
    //[SerializeField] private float comboDuration = 0.5f;
    private float comboTime;

    public bool isInvincible = false; //无敌
    public bool isUnstoppable = false;//霸体
    float time = 0;
    [Header("CounterAttack")]
    public float counterAttackDuration = 0.4f;
    public bool isParrying = false;
    [SerializeField] public float parryCD = 1.0f;
    public float parryTimer=0f;

    public GameObject sword;
    public PlayerAudio playerAudio;

    [Space]
    public float wallSlideTimer=0f;

    //UI控制
    [SerializeField]public UI UI;
    //玩家最近的安全位置(防止玩家坠崖)
    public Vector2 lastSafePosition;

    public PlayerStatistic statistic {  private set ; get; }

    //技能
    public SkillManager skill;
    public Machine machine { get; private set; }
    //状态
    public PlayerIdolState idolState { get; private set; }
    public PlayerGroundedState groundedState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }  
    public PlayerAirState airState { get; private set; }    
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; } 
    public PlayerPrimaryAttackState primaryAttackState { get; private set; }
    public PlayerCounterAttackState counterAttackState { get; private set; }
    public PlayerAimSwordState aimSwordState { get; private set; }
    public PlayerCatchSwordState catchSwordState { get; private set; }
    public PlayerBlackHoleState blackHoleState { get; private set; }
    public PlayerDeadState deadState { get; private set; }

    public PlayerStunnedState stunnedState { get; private set; }

    public PlayerFallingState fallingState { get; private set; }    
    protected override void Awake()
    {
        base.Awake();
        skill = SkillManager.instance;
        statistic = GetComponent<PlayerStatistic>();
        playerAudio = GetComponentInChildren<PlayerAudio>();



        machine = new Machine();
        moveState = new PlayerMoveState(machine, this, "Move");
        idolState = new PlayerIdolState(machine, this, "Idol");
        groundedState = new PlayerGroundedState(machine, this, "");
        jumpState = new PlayerJumpState(machine, this, "Jump");
        airState = new PlayerAirState(machine, this, "Jump");
        dashState = new PlayerDashState(machine, this, "Dash");
        wallSlideState = new PlayerWallSlideState(machine, this, "WallSlide");
        wallJumpState = new PlayerWallJumpState(machine, this, "Jump");
        primaryAttackState = new PlayerPrimaryAttackState(machine, this, "Attack");
        counterAttackState = new PlayerCounterAttackState(machine, this, "CounterAttack");
        aimSwordState = new PlayerAimSwordState(machine, this, "AimSword");
        catchSwordState = new PlayerCatchSwordState(machine, this, "CatchSword");
        blackHoleState = new PlayerBlackHoleState(machine, this, "BlackHole");
        deadState = new PlayerDeadState(machine, this, "Dead");
        fallingState = new PlayerFallingState(machine, this, "Falling");
        stunnedState = new PlayerStunnedState(machine, this, "Stunned");
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        InvokeRepeating("GetSafePosition", 0f, 3f);

        base.Start();
        machine.Initialize(idolState);

    }

    // Update is called once per frame
    protected override void Update()
    {
        moveSpeed = statistic.speed.GetValue();
        //暂停游戏停止玩家所有动作
        if(Time.timeScale == 0) return;

        
        //
        x = rb.velocity.x; y=rb.velocity.y;

        //调用状态机
        machine.Update();
        base.Update();

        //解决滑墙滑不下来的bug
        if (wallSlideTimer>0)
        {
            wallSlideTimer -= Time.deltaTime;
        }
        //冲刺CD
        if(dashTimer>0)
        {
            dashTimer -= Time.deltaTime;
        }
        //弹反CD
        if(parryTimer>0)
        {
            parryTimer -= Time.deltaTime;
        }
        //同步AttackComb
        attackCombo = primaryAttackState.comboCounter;
        //使用药水
        if(Input.GetKeyDown (KeyCode.Alpha1))
        {
            Inventory.Instance.UseFlask();
        }
        //无敌频闪FX
        FlickeringFX();
    }

    public void AssignMewSword(GameObject newSword)
    {
        sword = newSword;
    }
    public void AssignMewSword()
    {
        Destroy(sword);
    }


    //弹反成功
    public bool CheckParrySuccessfully()
    {
        if (isParrying)
        {
            isParrying = false;
            
            ani.SetBool("SuccessfullyCounter", true);
            machine.currentState.stateTimer = 10.0f;
            return true;
        }
        return false;
    }
    //携程
    public IEnumerator BusyFor(float value)
    {
        isBusy = true;
        yield return new WaitForSeconds(value);
        isBusy=false;
    }

    //水平移动
    public void Move(float value)
    {
        //水平移动
        rb.velocity = new Vector2(value * moveSpeed, rb.velocity.y);
        FilpController();
    }
    //跳跃
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    //冲刺技能
    public void Dash()
    {
        rb.velocity = new Vector2(facingDir * dashSpeed, 0);
       
    }
  
    //动画播放关键帧脚本
    public void AnimationTrigger()
    {
        machine.currentState.AnimationFinishTrigger();
    }
    //受击眩晕
    public void BeStunned(Vector2 _direction)
    {
        if(_direction.x < transform.position.x)
        {
            this.SetVelocity(2f, 5f);
        }
        else
        {
            this.SetVelocity(-2f, 5f);
        }
        //受击无敌
        StartCoroutine(GiveInvincible(1.8f));
        machine.ChangeState(stunnedState);
    }
    //受击无敌
    public IEnumerator GiveInvincible(float _time)
    {
        this.isInvincible = true;

        yield return new WaitForSeconds(_time);

        this.isInvincible = false;

    }
    //受击频闪FX
    private void FlickeringFX()
    {
        
        if(isInvincible)
        {
            
            time += Time.deltaTime; 
            if(time >= 0.1f)//振荡周期
            {
                if(sr.color.a != 0)
                {
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
                }
                else if(sr.color.a == 0)
                {
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 255);
                }
                time = 0;
            }
        }
        if(!isInvincible) 
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 255);
        }
    }
    //每隔3秒记录一次玩家位置
    private void GetSafePosition()
    {
        //记录玩家最后一次在平台的位置
        if (isGrounded)
        {
            lastSafePosition = transform.position;
        }
    }
    //减缓时间
    public IEnumerator SlowDownTime(float _scale,float _time)
    {
        Time.timeScale = _scale;

        yield return new WaitForSeconds(_time);

        Time.timeScale = 1f;

    }

}
    

