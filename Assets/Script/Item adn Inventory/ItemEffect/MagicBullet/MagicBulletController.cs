using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float flySpeed;
    [SerializeField] private float maxFlyTimeLimit;
    private float spawnTime;
    [SerializeField] private LayerMask wall;
    [SerializeField] private float distance;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
        if (Physics2D.Raycast(transform.position, Vector2.right, distance, wall))
        {
            DestoryThis();
        }
        if(Time.time > spawnTime + maxFlyTimeLimit) 
        {
            DestoryThis();
        }
    }

    public void Setup()
    {
        spawnTime = Time.time;
        Player player = PlayerManager.instance.player;
        rb.velocity = new Vector2 (flySpeed * player.facingDir, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = PlayerManager.instance.player;
        if (collision.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            player.statistic.DoMagicDamage(enemy.statistic, 1.2f);
        }
        
    }
    public void DestoryThis()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,
           new Vector3(transform.position.x +distance, transform.position.y));
    }

}
