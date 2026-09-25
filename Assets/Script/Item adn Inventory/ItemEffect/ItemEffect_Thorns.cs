using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thorns Effect", menuName = "Data/Item Effect/Thorns Effect")]
public class ItemEffect_Thorns : ItemEffect
{
    public override void ExecuteEffectWhenBeHit(Enemy _target)
    {
        base.ExecuteEffectWhenBeHit(_target);

        Player player = PlayerManager.instance.player;
        player.statistic.DoMagicDamage(_target.statistic, 0.2f);

    }
}
