using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBlackholeController : MonoBehaviour
{
    public Player player;

    [SerializeField] bool canGrow;
    [SerializeField] bool canShrink;
    [SerializeField] float growSpeed;
    [SerializeField] Vector2 maxSize;
    [SerializeField] List<Transform> targetTrans;

    private void Update()
    {
        
        if(canGrow)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, maxSize, Time.deltaTime * growSpeed);
            if (transform.localScale.x >= maxSize.x*0.98)
            {
                AttackEnemy();
            }
            
        }
        if(canShrink)
        {
            transform.localScale = Vector2.Lerp(transform.localScale,new Vector2(0,0), Time.deltaTime * growSpeed*3);
            if(transform.localScale.x < maxSize.x*0.2) 
            {
                for (int i = 0; i < targetTrans.Count; i++)
                {
                    Enemy newEnemy = targetTrans[i].GetComponent<Enemy>();
                    if (newEnemy != null)
                    {
                        newEnemy.FreezeTime(false);
                    }
                }
                Destroy(gameObject);
                player.machine.ChangeState(player.idolState);
            }
        }
    }

    private void Awake()
    {
        
    }

    public void SetupBlackHole(Transform transform,float size,float spped)
    {
        player = PlayerManager.instance.player;
        maxSize.x = size;
        maxSize.y = size;
        canGrow = true;
        growSpeed = spped;
        this.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy newEnemy = collision.GetComponent<Enemy>();
        if (newEnemy!=null && canGrow)
        {
            targetTrans.Add(collision.transform);
            newEnemy.FreezeTime(true);
        }
    }

    private void AttackEnemy()
    {
        if (targetTrans.Count <= 0)
        {
            //没有目标时
            canGrow = false;
            canShrink = true;
            return;
        }
        if (targetTrans.Count > 0)
        {
            for (int i = 0; i < targetTrans.Count; i++)
            {
                SkillManager.instance.clone.CreateClone(targetTrans[i]);
            }
            StartCoroutine("BusyFor", 1.5f);
            canGrow = false;
        }
    }

    private IEnumerator BusyFor(float value)
    {
        yield return new WaitForSeconds(value);
        canShrink = true;
    }
}
