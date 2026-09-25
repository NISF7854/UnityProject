using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : EntityBuff
{

   public override void Update()
   {
    base.Update();
   }
   public override void AddBuff(BuffData buff)
   {
    base.AddBuff(buff);
   }
   public override void RemoveBuff(BuffData buff)
   {
    base.RemoveBuff(buff);
   }
   public override void UpdateBuff()
   {
    base.UpdateBuff();
   }
}
