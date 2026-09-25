using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if(_player.GetComponent<Player>() != null) 
        {
            Player player = _player.GetComponent<Player>();
            player.machine.ChangeState(player.stunnedState);
            player.transform.position = player.lastSafePosition;
            player.statistic.LostHealthDirectly(player.statistic.maxHealth.GetValue() * 0.3f);

            StartCoroutine(player.GiveInvincible(1.5f));
        }
    }

}
