using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillSwordController : MonoBehaviour
{
    [SerializeField] private float returnSpeed;
    private Animator ani;
    private Rigidbody2D rb;
    private CapsuleCollider2D ccd;
    private Player player;

    //旋转动画
    private bool canRotate = true;
    private bool isReturning;
    //敌人之间弹射
    private bool isBouncing=false;
    private int amountOfBounce=4;
    [SerializeField] private List<Transform> enemyTarget;
    private int targetIndex=1;

    private void Awake()
    {
        ani = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ccd = GetComponent<CapsuleCollider2D>();
       
    }

    private void Start()
    {
        player = PlayerManager.instance.player;
    }


    private void Update()
    {
        if(canRotate)
        {
            transform.right = rb.velocity;
        }
        //召唤剑返回
        if(isReturning)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerManager.instance.player.transform.position, returnSpeed*Time.deltaTime*10);
            if(Vector2.Distance(transform.position, PlayerManager.instance.player.transform.position) < 0.2)
            {
                PlayerManager.instance.player.AssignMewSword();
            }
        }
        //弹射
        if(isBouncing)
        {
            rb.velocity = new Vector2 (0, 0);
            
            transform.position = Vector2.MoveTowards(transform.position, enemyTarget[targetIndex].position, 20*Time.deltaTime);
            if (Vector2.Distance(transform.position, enemyTarget[targetIndex].position) < 0.1f)
            {
                targetIndex++;
                if(targetIndex >= enemyTarget.Count) 
                {
                    targetIndex = 0;
                }
                amountOfBounce--;
            }
            if(amountOfBounce <=0)
            {

                ReturnSword();
            }
        }
        
    }
    public void SetupSword(Vector2 dir,float gravityScale)
    {
        rb.velocity = dir;
        rb.gravityScale = gravityScale;

        ani.SetBool("Rotate", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isReturning)
            return;
        
        if (collision.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            player.statistic.DoDamage(enemy.statistic);
            //收集受击目标周围敌人
            if (enemyTarget.Count <= 0)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10);

                foreach (var i in colliders)
                {
                    if (i.GetComponent<Enemy>() != null && !(i.GetComponent<Enemy>().isDead) )
                    {
                        enemyTarget.Add(i.transform);
                    }
                }
            }

        }
        //两个敌人以上开始弹射
        if(enemyTarget.Count>=2)
        {
            isBouncing = true;
            rb.isKinematic = true;
            return;
        }
        StuckIn(collision);
    }

    private void StuckIn(Collider2D collision)
    {
        
        ani.SetBool("Rotate", false);
        canRotate = false;
        ccd.enabled = false;

        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        transform.parent = collision.transform;
    }

    public void ReturnSword()
    {
        isBouncing = false;
        ani.SetBool("Rotate", true);
        transform.parent = null;
        rb.isKinematic = true;
        isReturning = true;
    }
}
