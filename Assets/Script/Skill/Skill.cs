using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;

    protected Player player;

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }
    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
    }

    public virtual bool CanUseSkill()
    {
        if(cooldownTimer <= 0)
        {
            UseSkill();
            cooldownTimer = cooldown;
            return true;
        }
        //Skill is on cooldown
        return false;
    }

    public virtual void UseSkill()
    {
        //
    }
}
