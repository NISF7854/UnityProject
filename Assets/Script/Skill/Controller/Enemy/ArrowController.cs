using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float flyingSpeed;
    Enemy_Archer archer;
    [SerializeField]LayerMask wallCheck;

    float spawnTime;
    float maxFlyTimeLimit = 4.0f;


    Rigidbody2D rb;

    void Start()
    {
        spawnTime = Time.time;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        rb.velocity = new Vector2(flyingSpeed * 5.0f, 0);

        //Åöµ½Ç½Ìå´Ý»Ù
        if (Physics2D.Raycast(transform.position, Vector2.right, 0.45f, wallCheck))
        {
            Destroy(gameObject);
        }
        //·ÉÐÐ×î´ó¾àÀë´Ý»Ù
        if (Time.time > spawnTime + maxFlyTimeLimit)
        {
            Destroy(gameObject);
        }

    }

    public void SetUp(float _speed,Enemy_Archer _archer)
    {
        flyingSpeed = _speed;
        archer = _archer;
    }

    private void OnTriggerEnter2D(Collider2D _player)
    {
        
        if(_player.GetComponent<Player>() != null)
        {
            Debug.Log("1");
            archer.statistic.DoDamage(_player.GetComponent<Player>().statistic);

            Destroy(gameObject);
        }
    }
}
