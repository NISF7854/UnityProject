using System.Text;
using UnityEditor;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Amulet,
    Flask
}

[CreateAssetMenu(fileName = "New Item Data",menuName ="Data/Equipment")]
public class ItemData_Equipment : ItemData
{
    public EquipmentType equipmentType;//武器类型
    public ItemEffect[] itemEffects;//词条
    public string effectDescription;
    


    [Header("Attack")]
    public float strength;//攻击力
    public float criticalRate;//暴击率
    public float criticalPower;//暴击伤害

    public float magic;//法术强度

    [Header("Resistance")]
    public float armor;//护甲
    public float magicResistance;//魔抗

    [Header("Health")]
    public float maxHealth;//最大生命值

    [Header("Magic State")]
    public float fireDamage;//火伤
    public float iceDamage;//冰伤
    public float lightningDamage;//雷伤

    //武器附加属性
    public void AddModifiers()
    {
        PlayerStatistic playerStatistic = PlayerManager.instance.player.statistic;

        playerStatistic.strength.AddModifier(strength, ModifierType.Add);
        playerStatistic.criticalRate.AddModifier(criticalRate, ModifierType.Add);
        playerStatistic.criticalPower.AddModifier(criticalPower, ModifierType.Add   );
        playerStatistic.magic.AddModifier(magic, ModifierType.Add);
        playerStatistic.armor.AddModifier(armor, ModifierType.Add);
        playerStatistic.magicResistance.AddModifier(magicResistance , ModifierType.Add);
        playerStatistic.maxHealth.AddModifier(maxHealth, ModifierType.Add);
        playerStatistic.fireDamage.AddModifier(fireDamage, ModifierType.Add);
        playerStatistic.iceDamage.AddModifier(iceDamage, ModifierType.Add);
        playerStatistic.lightningDamage.AddModifier(lightningDamage, ModifierType.Add);
    }
    public void RemoveModifiers() 
    {
        PlayerStatistic playerStatistic = PlayerManager.instance.player.statistic;

        playerStatistic.strength.RemoveModifier(strength,ModifierType.Add);
        playerStatistic.criticalRate.RemoveModifier(criticalRate, ModifierType.Add);
        playerStatistic.criticalPower.RemoveModifier(criticalPower, ModifierType.Add);
        playerStatistic.magic.RemoveModifier(magic, ModifierType.Add);
        playerStatistic.armor.RemoveModifier(armor, ModifierType.Add);
        playerStatistic.magicResistance.RemoveModifier(magicResistance, ModifierType.Add);
        playerStatistic.maxHealth.RemoveModifier(maxHealth, ModifierType.Add);
        playerStatistic.fireDamage.RemoveModifier(fireDamage, ModifierType.Add);
        playerStatistic.iceDamage.RemoveModifier(iceDamage, ModifierType.Add);
        playerStatistic.lightningDamage.RemoveModifier(lightningDamage, ModifierType.Add);
    }
    //执行词条效果
    public void ExecuteAllEffectsWhenHIt(Enemy _target)
    { 
        foreach(var effect in itemEffects)
        {
            effect.ExecuteEffectWhenHit(_target);
        }
    }
    public void ExecuteAllEffectsWhenAttack()
    {
        foreach (var effect in itemEffects)
        {
            effect.ExecuteEffectWhenAttack();
        }

    }
    public void ExecuteAllEffectsWhenActive()
    {
        foreach (var effect in itemEffects)
        {
            effect.ExecuteEffectWhenActive();
        }
    }
    public void ExecuteAllEffectsWhenBeHit(Enemy _target)
    {
        foreach (var effect in itemEffects)
        {
            effect.ExecuteEffectWhenBeHit(_target);
        }
    }

    //
    public string GetStatisticText()
    {
        StringBuilder stb = new StringBuilder();
        if(strength > 0)
        {
            stb.Append("+ "+strength.ToString()+ " 攻击力 ");
            stb.AppendLine();
        }
        if (magic > 0)
        {
            stb.Append("+ " + magic.ToString() + " 法强 ");
            stb.AppendLine();
        }
        if (criticalRate > 0)
        {
            stb.Append("+ " + criticalRate.ToString() + " 暴击率 ");
            stb.AppendLine();
        }
        if (criticalPower > 0)
        {
            stb.Append("+ " + criticalPower.ToString() + " 暴击伤害 ");
            stb.AppendLine();
        }
        if (armor > 0)
        {
            stb.Append("+ " + armor.ToString() + " 护甲 ");
            stb.AppendLine();
        }
        if (magicResistance > 0)
        {
            stb.Append("+ " + magicResistance.ToString() + " 魔抗 ");
            stb.AppendLine();
        }
        if (maxHealth > 0)
        {
            stb.Append("+ " + maxHealth.ToString() + " 生命值 ");
        }

        return stb.ToString();
    }

    

}


