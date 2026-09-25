using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStrikeController : MonoBehaviour
{
    Player player;
    

    public void Setup()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = PlayerManager.instance.player;
        if(collision.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            player.statistic.DoMagicDamage(enemy.statistic, 0.2f);
        }
    }

    public void DestoryThis()
    {
        Destroy(gameObject);
    }
}
