using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_StateToolTip : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;



    private void Awake()
    {
        
    }

    public void Setup(StatisticType _type)
    {
        switch (_type)
        {
            case StatisticType.Strength:
                title.text = "攻击力";
                description.text = "用于提升普通攻击和一些物理技能的伤害";
                break;
            case StatisticType.Armor:
                title.text = "护甲";
                description.text = "减少自身受到的物理伤害";
                break;
            case StatisticType.Magic:
                title.text = "法强";
                description.text = "用于提升武器魔法技能的伤害";
                break;
            case StatisticType.MagicResistance:
                title.text = "魔抗";
                description.text = "减少自身受到的魔法伤害";
                break;
            case StatisticType.CriticalPower:
                title.text = "暴击伤害";
                description.text = "暴击时额外造成的伤害倍率";
                break;
            case StatisticType.CriticalRate:
                title.text = "暴击率";
                description.text = "普通攻击暴击的概率";
                break;
            case StatisticType.MaxHealth:
                title.text = "最大生命值";
                description.text = "玩家的生命上限";
                break;


        }
    }


}
