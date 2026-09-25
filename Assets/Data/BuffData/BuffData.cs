using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    Debuff, // 负面效果
    Buff // 正面效果
}

public enum BuffEffect
{
    Strength,
    Speed,
    Armor
}

[CreateAssetMenu(fileName = "New Buff Data", menuName = "Data/Buff")]
public class BuffData : ScriptableObject
{
    public string buffName; // buff名称
    public BuffType buffType; // buff类型
    public BuffEffect buffEffect; // buff效果
    public float buffValue; // buff值
    public float buffDuration; // buff持续时间
    public float buffTimer; // buff持续时间计时器
    public float buffCooldown; // buff冷却时间
    public float buffStackable; // buff堆叠数量
    public float buffStackableMax; // buff堆叠最大数量
    public float buffStackableMin; // buff堆叠最小数量
    public Sprite buffIcon; // buff图标

    protected Player player;


    public virtual void BuffStart()
    {
        Player player = PlayerManager.instance.player;
        
    }

    public virtual void BuffEnd()
    {
        Player player = PlayerManager.instance.player;
    
    }

    public virtual void BuffUpdate()
    {

    }

}
