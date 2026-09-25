using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeClashTrigger : MonoBehaviour
{
    Enemy_Slime slime;



    private void Awake()
    {
        slime = GetComponentInParent<Enemy_Slime>();
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if(slime.isClashing == false)
        {
            return;
        }


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
