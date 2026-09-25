using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SlimeStatistic : EnemyStatistic
{
    Enemy_Slime slime;

    protected override void Start()
    {
        base.Start();

        slime = GetComponent<Enemy_Slime>();
        healthUIController = GetComponentInChildren<HealthUIController>();
    }
    public override void DoDamage(EntityStatistic target)
    {
        base.DoDamage(target);
    }

    public override void TakeDamage(EntityStatistic _attack,float value)
    {
        base.TakeDamage(_attack, value);
        if (slime.isDead)
        {
            return;
        }
        //ÊÜ»÷×´Ì¬
        slime.BeStunned(_attack.transform.position, 1.2f,slime.stunDirection);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void TakeMagicDamage(EntityStatistic _attack,float value)
    {
        base.TakeMagicDamage(_attack, value);
        if (slime.isDead)
        {
            return;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        slime.machine.ChangeState(slime.deadState);
        slime.isDead = true;
        //healthUIController.DestroyThis();
    }
    

}
