using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_NightBorneStatistic : EnemyStatistic
{

    Enemy_NightBorne ntb;



    protected override void Start()
    {
        base.Start();
        ntb = GetComponent<Enemy_NightBorne>();
        healthUIController = GetComponentInChildren<HealthUIController>();
    }

    protected override void Update()
    {
        base.Update();
    }
    public override void DoDamage(EntityStatistic target)
    {
        base.DoDamage(target);
    }

    public override void TakeCriticalDamage(EntityStatistic _attacker, float value)
    {
        base.TakeCriticalDamage(_attacker, value);
    }

    public override void TakeDamage(EntityStatistic _attacker, float value)
    {
        base.TakeDamage(_attacker, value);
        if (ntb.isDead)
        {
            return;
        }
        //ÊÜ»÷×´Ì¬
        if(ntb.unstoppable == false)
        {
            ntb.BeStunned(_attacker.transform.position, 0.8f, ntb.stunDirection);
        }
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void TakeMagicDamage(EntityStatistic _attacker, float value)
    {
        base.TakeMagicDamage(_attacker, value);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        ntb.machine.ChangeState(ntb.deadState);
        ntb.isDead = true;
    }
}
