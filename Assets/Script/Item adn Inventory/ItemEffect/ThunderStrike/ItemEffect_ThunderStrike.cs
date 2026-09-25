using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thunder Strike Effect", menuName = "Data/Item Effect/Thunder Strike")]
public class ItemEffect_ThunderStrike : ItemEffect
{
    public GameObject thunderPrefab;


    public override void ExecuteEffectWhenHit(Enemy _target)
    {
        base.ExecuteEffectWhenHit(_target);

        Player player = PlayerManager.instance.player;
        GameObject newThunder = Instantiate(thunderPrefab,_target.transform.position,Quaternion.identity);


    }
}
