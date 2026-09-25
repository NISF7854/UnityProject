using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thorns Effect", menuName = "Data/Item Effect/Speed Sword Effect")]
public class ItemEffect_SpeedSword : ItemEffect
{
    public override void ExecuteEffectWhenAttack()
    {
        base.ExecuteEffectWhenAttack();
        Player player = PlayerManager.instance.player;
        player.statistic.SetBuff(player.statistic.speed, 0.3f, 10.0f, ModifierType.Multi);
    }
}
