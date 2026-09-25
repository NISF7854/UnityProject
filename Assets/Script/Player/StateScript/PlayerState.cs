using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState
{
    protected Machine machine;
    protected Player player;
    private string animBoolName;
    protected Rigidbody2D rb;
    public float xInput { get; private set; }
    //×´Ì¬¼ÆÊ±Æ÷
    public float stateTimer;
    public float stateDuration;
    //´¥·¢Æ÷
    public bool triggerCalled;


    public PlayerState(Machine machine, Player player, string animBoolName)
    {
        this.machine = machine;
        this.player = player;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        rb = player.rb;
        player.ani.SetBool(animBoolName, true);
        triggerCalled = false;

    }
    public virtual void Update()
    {
        
        xInput = Input.GetAxisRaw("Horizontal");
        player.ani.SetFloat("yVelocity", rb.velocity.y);
        
        
    }
    public virtual void Exit()
    {
        player.ani.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
