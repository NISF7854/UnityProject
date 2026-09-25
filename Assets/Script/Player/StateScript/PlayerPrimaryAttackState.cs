using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    public int comboCounter = 0;
    private float comboWindow = 0.1f;
    private float lastTimeAttack;

    public PlayerPrimaryAttackState(Machine machine, Player player, string animBoolName) : base(machine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        player.SetZoreVelocity();
        base.Enter();
        
        comboCounter %= 3;

        if(Time.time>= lastTimeAttack+comboWindow) 
        {
            comboCounter = 0;
        }
        //Debug.Log(comboCounter);

        //¹¥»÷ÒôÐ§
        player.playerAudio.PlaySFX(comboCounter*2 + Random.Range(0,2));
    }

    public override void Exit()
    {
        base.Exit();
        lastTimeAttack = Time.time;
        if (Time.time >= lastTimeAttack + comboWindow)
        {
            comboCounter = 0;
            
        }
        //Debug.Log("this is testing");
    }

    public override void Update()
    {
        base.Update();
        player.ani.SetInteger("ComboCounter", comboCounter);
        if (triggerCalled)
        {
            machine.ChangeState(player.idolState);
            comboCounter++;
            
            player.ani.SetInteger("ComboCounter", comboCounter);
            return;
        }
        player.SetZoreVelocity();
    }

}
