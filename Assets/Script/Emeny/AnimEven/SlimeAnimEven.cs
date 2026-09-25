using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimEven : MonoBehaviour
{
    private Enemy_Slime slime;

    private void Awake()
    {
        slime = GetComponentInParent<Enemy_Slime>();
    }

    //¹¥»÷ÉúÐ§Ö¡
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(slime.attackCheck.transform.position, slime.attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                if (hit.GetComponent<Player>().CheckParrySuccessfully())
                {
                    slime.machine.ChangeState(slime.stunnedState);
                    return;
                }
                Player player = hit.GetComponent<Player>();
                slime.statistic.DoDamage(player.statistic);
                if (Inventory.Instance.GetEquipmentDataByType(EquipmentType.Amulet) != null)
                    Inventory.Instance.GetEquipmentDataByType(EquipmentType.Amulet).ExecuteAllEffectsWhenBeHit(slime);
            }
        }
    }




}
