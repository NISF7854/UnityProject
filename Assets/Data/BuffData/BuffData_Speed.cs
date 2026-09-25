using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buff Data", menuName = "Data/Buff/Speed")]
public class BuffData_Speed : BuffData
{
    public override void BuffStart()
    {   
        base.BuffStart();

        player.statistic.speed.AddModifier(buffValue,ModifierType.Multi);

    }

    public override void BuffEnd()
    {
        base.BuffEnd();
        player.statistic.speed.RemoveModifier(buffValue,ModifierType.Multi);
    }

    public override void BuffUpdate()
    {
        base.BuffUpdate();
    }
    
}
