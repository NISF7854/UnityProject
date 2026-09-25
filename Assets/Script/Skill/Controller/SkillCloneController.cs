using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCloneController : MonoBehaviour
{
    public Player player;

    private Animator ani;
    private SpriteRenderer sr;
    [SerializeField] private float losingSpeed;
    private float cloneTimer;

    [SerializeField] Transform attackCheck;
    [SerializeField] private float attackRadius;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        player = PlayerManager.instance.player;
    }
    private void Update()
    {
        cloneTimer-= Time.deltaTime;
        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * losingSpeed));
            if(sr.color.a <= 0 )
            {
                Destroy(gameObject);
            }
        }
    }
    //·ÖÉí¹¥»÷
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.transform.position,attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                player.statistic.DoDamage(enemy.statistic);

            }
        }
    }


    public void SetupClone(Transform trans,float duration,bool canAttack)
    {
        if(canAttack) 
        {
            ani.SetInteger("AttackNumber", Random.Range(1,4));
        }
        if(PlayerManager.instance.player.facingDir==-1)
        {
            transform.Rotate(0, 180, 0);
        }
        
        transform.position = trans.position;
        cloneTimer = duration;
    }
}
