using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Primary Heal Flask Effect", menuName = "Data/Item Effect/Primary Heal Flask Effect")]
public class ItemEffect_PrimaryHealFlask : FlaskEffect
{

    public override void ExecuteEffectWhenActive()
    {
        base.ExecuteEffectWhenActive();
        Player player = PlayerManager.instance.player;
        //жнаф
        if(amount <= 0)
        {
            return;
        }
        if (player.statistic.maxHealth.GetValue() - player.statistic.currentHealth < 0.1f )
        {
            return;
        }

        player.statistic.Heal(player.statistic.maxHealth.GetValue() * (0.30f+ 0.1f * flaskLevel ));
        amount--;
    }
}
