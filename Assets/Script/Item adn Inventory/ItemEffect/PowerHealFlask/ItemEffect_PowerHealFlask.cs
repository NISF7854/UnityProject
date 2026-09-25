using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Heal Flask Effect", menuName = "Data/Item Effect/Power Heal Flask Effect")]
public class ItemEffect_PowerHealFlask : FlaskEffect
{
    public override void ExecuteEffectWhenActive()
    {
        base.ExecuteEffectWhenActive();
        Player player = PlayerManager.instance.player;
        //жнаф
        if (amount <= 0)
        {
            return;
        }
        if (player.statistic.maxHealth.GetValue() - player.statistic.currentHealth < 0.1f)
        {
            return;
        }

        player.statistic.Heal(player.statistic.maxHealth.GetValue() * (0.30f + 0.1f * flaskLevel));
        player.statistic.SetBuff(player.statistic.strength, 0.3f, 10.0f, ModifierType.Multi);
        player.statistic.SetBuff(player.statistic.magic, 0.3f,10.0f, ModifierType.Multi);

        amount--;
    }
}
