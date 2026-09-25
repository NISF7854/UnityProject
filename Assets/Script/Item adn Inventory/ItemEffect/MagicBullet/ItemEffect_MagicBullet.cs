using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Magic Bullet Effect", menuName = "Data/Item Effect/Magic Bullet")]
public class ItemEffect_MagicBullet : ItemEffect
{

    public GameObject MagicBulletPrefab;


    public override void ExecuteEffectWhenAttack()
    {
        base.ExecuteEffectWhenAttack();
        Player player = PlayerManager.instance.player;
        if(player.attackCombo == 2)
        {
            GameObject magicBullet = Instantiate(MagicBulletPrefab, player.transform.position, player.transform.rotation);
            magicBullet.GetComponent<MagicBulletController>().Setup();
        }
        
    }
}
