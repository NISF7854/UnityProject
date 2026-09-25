using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistic : EntityStatistic
{
    Player Player { get; set; }

    protected override void Start()
    {
        base.Start();
        Player = PlayerManager.instance.player;

        
    }

    public override void DoDamage(EntityStatistic target)
    {
        
         //暴击
        if (Random.Range(1, 101) <= criticalRate.GetValue()) 
        {
            DoCriticalDamage(target);
            return;
        }

        base.DoDamage(target);
        Player.fx.ScreenShake(new Vector3(0.08f,0.03f,0));
        //命中特效
        Player.fx.HitFX(target.transform);
    }

    public void DoCriticalDamage(EntityStatistic target)
    {
        Player.fx.ScreenShake(new Vector3(0.08f,0.03f,0));
        //命中特效
        Player.fx.CriticalHitFX(target.transform);
        float totalDamage = strength.GetValue() * criticalPower.GetValue() * damageDealtMultiplier.GetValue();
        target.TakeDamage(this, totalDamage);
    }

    public override void TakeDamage(EntityStatistic _attacker, float value)
    {
        if(Player.isInvincible) 
        {
            //无敌时返回函数
            return;
        }
        //受击眩晕
        Player.BeStunned(_attacker.transform.position);

        base.TakeDamage(_attacker,value);

        //承受伤害过高FX
        float finalDamage = value - armor.GetValue();
        if(finalDamage > maxHealth.GetValue() * 0.4f)
        {
            StartCoroutine(Player.SlowDownTime(0.25f, 0.2f));
            Player.fx.ScreenShake(new Vector3(0.1f, 0.02f, 0));
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void TakeMagicDamage(EntityStatistic _attacker, float value)
    {
        if (Player.isInvincible)
        {
            //无敌时返回函数
            return;
        }

        base.TakeMagicDamage(_attacker, value);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    //直接扣血
    public void LostHealthDirectly(float _value)
    {
        if (_value > 0)
        {
            currentHealth -= _value;
        }
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        Player.machine.ChangeState(Player.deadState);

        Player.UI.fadeScreen.FadeOut();
        
        Player.isDead = true;

    }
}
