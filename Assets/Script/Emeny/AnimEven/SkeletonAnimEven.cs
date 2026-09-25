using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimEven : MonoBehaviour
{
    private Enemy_Skeleton skeleton;

    private void Awake()
    {
        skeleton = GetComponentInParent<Enemy_Skeleton>();
    }
    private void AnimationTrigger()
    {
        skeleton.machine.currentState.AnimationFinishTrigger();
    }
    //攻击生效帧
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(skeleton.attackCheck.transform.position, skeleton.attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                if(hit.GetComponent<Player>().CheckParrySuccessfully())
                {
                    skeleton.machine.ChangeState(skeleton.stunnedState);
                    return;
                }
                Player player = hit.GetComponent<Player>();
                skeleton.statistic.DoDamage(player.statistic);
                if (Inventory.Instance.GetEquipmentDataByType(EquipmentType.Amulet) != null)
                    Inventory.Instance.GetEquipmentDataByType(EquipmentType.Amulet).ExecuteAllEffectsWhenBeHit(skeleton);
            }
        }
    }
    //反击窗口帧
    private void OpenCounterAttackWindow()
    {
        skeleton.OpenCounterAttackWindow();
    }
    private void CloseCounterAttackWindow()
    {
        skeleton.CloseCounterAttackWindow();
    }
   

    
}
