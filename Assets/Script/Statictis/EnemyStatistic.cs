using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistic : EntityStatistic
{
    public int level;
    public ItemDrop dropSystem;
    Enemy enemy;

    protected override void Start()
    {
        dropSystem = GetComponent<ItemDrop>();
        enemy = GetComponent<Enemy>();
        ModifyWithLevel(strength,0.35f);
        ModifyWithLevel(maxHealth, 0.46f);
        ModifyWithLevel(armor, 0.7f);

        base.Start();
    }
    public override void DoDamage(EntityStatistic target)
    {
        base.DoDamage(target);
    }

    public override void TakeDamage(EntityStatistic _attacker, float value)
    {
        base.TakeDamage(_attacker, value);
        
        
    }
    public void ModifyWithLevel(Value _value,float _rate)
    {
        _value.AddModifier(_value.GetBaseValue() * _rate * level,ModifierType.Add);
        
    }


    public override void Die()
    {
        dropSystem.DropItem();

        base.Die();
    }

}
