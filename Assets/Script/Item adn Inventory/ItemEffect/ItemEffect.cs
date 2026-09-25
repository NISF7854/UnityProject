using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Item Effect")]
public class ItemEffect : ScriptableObject
{
    public virtual void ExecuteEffectWhenHit(Enemy _target)
    {
        Debug.Log("Execute!");
    }
    public virtual void ExecuteEffectWhenAttack()
    {

    }
    public virtual void ExecuteEffectWhenActive() 
    {

    }
    public virtual void ExecuteEffectWhenBeHit(Enemy _target)
    {

    }
}
