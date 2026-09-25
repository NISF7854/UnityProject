using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ArcherStatistic : EnemyStatistic
{
    Enemy_Archer archer;



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
        if (archer.isDead)
        {
            return;
        }
        //ÊÜ»÷×´Ì¬
        archer.BeStunned(_attacker.transform.position, 0.8f, archer.stunDirection);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void TakeMagicDamage(EntityStatistic _attacker, float value)
    {
        base.TakeMagicDamage(_attacker, value);
        if (archer.isDead)
        {
            return;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Start()
    {
        base.Start();
        archer = GetComponent<Enemy_Archer>();
        healthUIController = GetComponentInChildren<HealthUIController>();
    }

    protected override void Update()
    {
        base.Update();
    }
    public override void Die()
    {
        base.Die();
        archer.machine.ChangeState(archer.deadState);
        archer.isDead = true;
        //healthUIController.DestroyThis();
    }

}
