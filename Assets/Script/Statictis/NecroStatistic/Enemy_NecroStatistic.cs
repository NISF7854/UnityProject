using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_NecroStatistic : EnemyStatistic
{
    Enemy_Necro necro;



    protected override void Start()
    {
        base.Start();

        necro = GetComponent<Enemy_Necro>();
    }

    protected override void Update()
    {
        base.Update();
    }
    

    public override void DoDamage(EntityStatistic target)
    {
        base.DoDamage(target);
    }

    public override void DoMagicDamage(EntityStatistic target, float _rate)
    {
        base.DoMagicDamage(target, _rate);
    }

    public override void TakeCriticalDamage(EntityStatistic _attacker, float value)
    {
        base.TakeCriticalDamage(_attacker, value);
    }

    public override void TakeDamage(EntityStatistic _attacker, float value)
    {
        base.TakeDamage(_attacker, value);
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
        necro.machine.ChangeState(necro.deadState);
        necro.isDead = true;
        //healthUIController.DestroyThis();
    }

}
