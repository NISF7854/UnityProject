using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerAnimEven : MonoBehaviour
{
    private Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
    }
    //攻击动画结束帧
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    //攻击生效帧
    private void AttackTrigger()
    {
        //施加武器特殊词条(进行攻击时)
        if (Inventory.Instance.GetEquipmentDataByType(EquipmentType.Weapon) != null)
        {
            Inventory.Instance.GetEquipmentDataByType(EquipmentType.Weapon).ExecuteAllEffectsWhenAttack();
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.transform.position, player.attackRadius);
        foreach(var hit in colliders)
        {
            if(hit.GetComponent<Enemy>() != null)
            {
                //敌人死亡时直接返回
                if(hit.GetComponent<Enemy>().isDead == true)
                {
                    return;
                }

                Enemy enemy = hit.GetComponent<Enemy>();
                //播放命中音效
                player.playerAudio.PlaySFX(11);
                player.statistic.DoDamage(enemy.statistic);;
                //施加武器特殊词条(命中敌人时)
                if(Inventory.Instance.GetEquipmentDataByType(EquipmentType.Weapon) != null)
                {
                    Inventory.Instance.GetEquipmentDataByType(EquipmentType.Weapon).ExecuteAllEffectsWhenHIt(enemy);
                }
                
            }
        }
    }
    //弹反动画结束帧
    private void FinishSuccessfullyCounterAttack()
    {
        player.AnimationTrigger();
    }

    //飞剑
    private void ThrowSwordTrigger()
    {
        player.skill.sword.CreateSword();
    }
}