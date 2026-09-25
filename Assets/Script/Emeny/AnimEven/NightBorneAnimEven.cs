using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAnimEven : MonoBehaviour
{
    Enemy_NightBorne ntb;



    void Start()
    {
        ntb = GetComponentInParent<Enemy_NightBorne>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(ntb.attackCheck.transform.position, ntb.attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                //if (hit.GetComponent<Player>().CheckParrySuccessfully())
                //{
                //    ntb.machine.ChangeState(ntb.stunnedState);
                //    return;
                //}
                Player player = hit.GetComponent<Player>();
                ntb.statistic.DoDamage(player.statistic);
                if (Inventory.Instance.GetEquipmentDataByType(EquipmentType.Amulet) != null)
                    Inventory.Instance.GetEquipmentDataByType(EquipmentType.Amulet).ExecuteAllEffectsWhenBeHit(ntb);
            }
        }
    }

    void FinishAttackTrigger()
    {
        ntb.machine.ChangeState(ntb.battleState);
    }

    void DeathRattleTrigger()
    {
        ntb.DeathRattle();
    }
}
