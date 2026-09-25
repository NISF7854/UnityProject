using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_SkeletonStatistic : EnemyStatistic
{
    Enemy_Skeleton skeleton;


    protected override void Start()
    {
        base.Start();
        skeleton = GetComponent<Enemy_Skeleton>();
        healthUIController = GetComponentInChildren<HealthUIController>();
    }

    public override void DoDamage(EntityStatistic target)
    {
        base.DoDamage(target);
    }

    public override void TakeDamage(EntityStatistic _attacker, float value)
    {
        if (skeleton.isDead)
        {
            return;
        }

        base.TakeDamage(_attacker, value);


        //ÊÜ»÷×´Ì¬
        skeleton.BeStunned(_attacker.transform.position, 0.8f, skeleton.stunDirection);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void TakeMagicDamage(EntityStatistic _attacker, float value)
    {
        base.TakeMagicDamage(_attacker, value);
        if (skeleton.isDead)
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
        skeleton.machine.ChangeState(skeleton.deadState);
        skeleton.isDead = true;
        //healthUIController.DestroyThis();
    }
}
