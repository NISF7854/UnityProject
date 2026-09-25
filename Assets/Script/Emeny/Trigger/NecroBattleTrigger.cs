using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroBattleTrigger : MonoBehaviour
{
    Enemy_Necro necro;

    // Start is called before the first frame update
    void Start()
    {
        necro = GetComponentInParent<Enemy_Necro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("10");
        if (collision.GetComponent<Player>() != null) 
        {
            necro.isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            necro.isPlayerInRange = false;
        }
    }
}
