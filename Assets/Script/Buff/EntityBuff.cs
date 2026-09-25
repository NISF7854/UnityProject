using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBuff : MonoBehaviour
{
    public List<BuffData> buffsBar = new List<BuffData>();//Buff列表
  



    public virtual void AddBuff(BuffData buff)
    {
        buffsBar.Add(buff);
        buff.BuffStart();
    }

    public virtual void RemoveBuff(BuffData buff)
    {
        buff.BuffEnd();
        buffsBar.Remove(buff);
    }

    public virtual void UpdateBuff()
    {
        foreach (var buff in buffsBar)
        {
            buff.BuffUpdate();
            buff.buffTimer += 1.0f;
            if (buff.buffTimer >= buff.buffDuration)
            {
                RemoveBuff(buff);
            }
        }
    }


    public virtual void Update()
    {
         //每一秒更新一次Buff
         float time = Time.time;
         if (time % 1 == 0)
         {
            UpdateBuff();
         }
    }
}
