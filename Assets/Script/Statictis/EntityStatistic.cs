using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum StatisticType
{
    Strength,
    CriticalRate,
    CriticalPower,
    Magic,
    Armor,
    MagicResistance,
    MaxHealth

}


public class EntityStatistic : MonoBehaviour
{
    [Header("Attack")]
    public Value strength;//攻击力
    public Value criticalRate;//暴击率
    public Value criticalPower;//暴击伤害

    public Value magic;//法术强度

    [Header("Resistance")]
    public Value armor;//护甲
    public Value magicResistance;//魔抗
    public Value speed;//速度

    [Header("Health")]
    public Value maxHealth;//最大生命值
    public float currentHealth;

    [Header("Magic State")]
    public Value fireDamage;//火伤
    public Value iceDamage;//冰伤
    public Value lightningDamage;//雷伤


    [Header("Buff")]
    public Value damageTakenMultiplier;//伤害承受倍率
    public Value damageDealtMultiplier;//伤害造成倍率



    public bool isIgnited;
    public bool isChilled;
    public bool isShocked;

    public bool canApplyIgnite;
    public bool canApplyChill;
    public bool canApplyShock;

    public float ignitedDuration;
    public float ignitedTimer;

    public GameObject damageNumberPrefab;
    public HealthUIController healthUIController;

    protected virtual void Update()
    {
        if(isIgnited) 
        {
            ignitedTimer -= Time.deltaTime;
            if(ignitedTimer < 0)
            {
                isIgnited = false;
                return;
            }




        }

    }

  
    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
        healthUIController = GetComponentInChildren<HealthUIController>();

        this.damageDealtMultiplier.SetValue(1f);//伤害造成倍率初始化为1
        this.damageTakenMultiplier.SetValue(1f);//伤害承受倍率初始化为1

    }
    //造成物理伤害
    public virtual void DoDamage(EntityStatistic _target)
    {
        float totalDamage = strength.GetValue() * damageDealtMultiplier.GetValue();
       
        _target.TakeDamage(this,totalDamage);
    }

    
    //造成法术伤害
    public virtual void DoMagicDamage(EntityStatistic target, float _rate)
    {
        float totalDamage = magic.GetValue() * _rate ;

        target.TakeMagicDamage(this, totalDamage);



        //float totalMagicalDamage = fireDamage.GetValue()+iceDamage.GetValue()+lightningDamage.GetValue();

        //canApplyIgnite = fireDamage.GetValue() > iceDamage.GetValue() && fireDamage.GetValue() > lightningDamage.GetValue();
        //canApplyChill = iceDamage.GetValue() > fireDamage.GetValue() && iceDamage.GetValue() > lightningDamage.GetValue();
        //canApplyShock = lightningDamage.GetValue() > fireDamage.GetValue() && lightningDamage.GetValue() > iceDamage.GetValue();

        //if(Mathf.Max(fireDamage.GetValue(), iceDamage.GetValue(),lightningDamage.GetValue()) <= 0)
        //{
        //    return;
        //}

        //target.BeAppliedAilments(canApplyIgnite,canApplyChill,canApplyShock);


    }
    //施加负面效果
    public virtual void BeAppliedAilments(bool _isIgnited,bool _isChilled,bool _isShocked)
    {
        if(_isIgnited)
        {
            isIgnited = true;
            ignitedTimer = ignitedDuration;
        }
        if(_isChilled)
        {
            isChilled = true;
        }
        if(_isShocked)
        {
            isShocked = true;
        }
    }

    //承受物理伤害
    public virtual void TakeDamage(EntityStatistic _attacker,float value)
    {
        float finalDamage = value * damageTakenMultiplier.GetValue();
        if (armor.GetValue() >= 0)
        {
            finalDamage = value - armor.GetValue();
        }

        

        //debug


        GetComponent<Entity>().DamageFXEffect();
        ShowDamageNumber(finalDamage,new Color(0.82f,0.46f,0.13f,1), 3.0f );

        if (finalDamage > 0)
        {
            currentHealth -= finalDamage;
        }
        if (healthUIController != null)
        {
            healthUIController.UpdateHealthBar(finalDamage);
        }
    }
    //承受暴击物理伤害
    public virtual void TakeCriticalDamage(EntityStatistic _attacker,float value)
    {
        float finalDamage = value * damageTakenMultiplier.GetValue();
        if (armor.GetValue() >= 0)
        {
            finalDamage = value - armor.GetValue();
        }

        GetComponent<Entity>().DamageFXEffect();
        ShowDamageNumber(finalDamage, new Color(0.54f, 0.10f, 0.13f, 1), 4.5f);
        if (finalDamage > 0)
        {
            currentHealth -= finalDamage;
        }
        if (healthUIController != null)
        {
            healthUIController.UpdateHealthBar(finalDamage);
        }
    }
    //承受法术伤害
    public virtual void TakeMagicDamage(EntityStatistic _attacker,float value)
    {
        float finalDamage = value * damageTakenMultiplier.GetValue();
        if(magicResistance.GetValue() >= 0)
        {
            finalDamage -= magicResistance.GetValue();
        }

        GetComponent<Entity>().DamageFXEffect();
        ShowDamageNumber(finalDamage, new Color(0.68f, 0.22f, 0.91f, 1), 3.2f);

        if (finalDamage > 0)
        {
            currentHealth -= finalDamage;
        }
        if (healthUIController != null)
        {
            healthUIController.UpdateHealthBar(finalDamage);
        }
    }


    //伤害跳字
    private void ShowDamageNumber(float finalDamage, Color _color,float _size)
    {
        Transform transform = GetComponent<Transform>();
        GameObject damageNumber = Instantiate(damageNumberPrefab, new Vector2(transform.position.x+Random.Range(-.5f,.5f),transform.position.y), Quaternion.identity);
        damageNumber.GetComponent<UI_DamageNumber>().Setup(finalDamage, _color, _size);
    }
    //回血
    public virtual void Heal(float _value)
    {
        if(currentHealth < maxHealth.GetValue())
        {
            currentHealth += _value;
            ShowDamageNumber(_value, new Color(46 / 255f, 139 / 255f, 87 / 255f), 1.2f);

            if(currentHealth >= maxHealth.GetValue())
            {
                currentHealth = maxHealth.GetValue();
            }
        }


        //回血特效TODO
        
    }
    //Buff和Debuff
    public virtual void SetBuff(Value _stat, float _modifier, float _duration, ModifierType _type)
    {
        StartCoroutine(IESetBuff(_stat,_modifier,_duration,_type));
    }

    private IEnumerator IESetBuff(Value _stat,float _modifier,float _duration, ModifierType _type)
    {
        if(_type == ModifierType.Add)
        {
            _stat.modifiersAdd.Add(_modifier);
            yield return new WaitForSeconds(_duration);
            _stat.modifiersAdd.Remove(_modifier);
        }
        if(_type == ModifierType.Multi)
        {
            _stat.modifiersMulti.Add(_modifier);
            yield return new WaitForSeconds(_duration);
            _stat.modifiersMulti.Remove(_modifier);
        }
    }

    public virtual void Die() 
    {
        
    }




    public Value GetStatisticByType(StatisticType _type) 
    {
        Value stat = null;

        switch(_type)
        {
            case StatisticType.Strength:
                stat = strength; break;
            case StatisticType.Magic: 
                stat = magic; break;
            case StatisticType.Armor: 
                stat = armor; break;
            case StatisticType.MagicResistance: 
                stat = magicResistance; break;
            case StatisticType.CriticalPower: 
                stat = criticalPower; break;
            case StatisticType.CriticalRate: 
                stat = criticalRate; break;
            case StatisticType.MaxHealth:
                stat = maxHealth; break;

        }
        return stat;
    }
}
