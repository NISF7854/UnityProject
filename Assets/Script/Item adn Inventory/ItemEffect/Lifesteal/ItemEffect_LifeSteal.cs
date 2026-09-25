using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Life Steal Effect", menuName = "Data/Item Effect/Life Steal")]
public class ItemEffect_LifeSteal : ItemEffect
{
    public float healPercent;

    public override void ExecuteEffectWhenHit(Enemy _target)
    {
        base.ExecuteEffectWhenHit(_target);
        Player player = PlayerManager.instance.player;
        player.statistic.Heal(player.statistic.maxHealth.GetValue() * healPercent);
            
    }
}
