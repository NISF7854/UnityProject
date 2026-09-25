using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class NecroBallController : MonoBehaviour
{
    Player player;
    Enemy_Necro necro;
    //飞行速度
    public float moveSpeed = 15f;
    //存在时长
    public float lastingTime = 1.5f;
    
    [SerializeField] private Transform iconTran;
    
    private Vector2 currentDirection; // 法球当前运动方向


    void Start()
    {
        
        player = PlayerManager.instance.player;
        
        currentDirection = (player.transform.position - transform.position).normalized;
    }


    void Update()
    {
        FollowPlayer();

        lastingTime -= Time.deltaTime;
        if (lastingTime <= 0) 
        {
            Destroy(gameObject);
        }


    }

    void FollowPlayer()
    {
        if (player == null) return;

        //计算玩家相对于法球的方向（目标方向）
        Vector2 toPlayer = (player.transform.position - transform.position).normalized;
        Debug.Log(toPlayer);

        // 2. 用插值让当前方向逐步靠近目标方向（核心：模拟惯性）
        // 数值越小（如0.05），转向越慢，惯性越强
        currentDirection = Vector2.Lerp(currentDirection, toPlayer, 0.005f);
        
        // 3. 按当前方向移动法球
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);



        //让法球朝向运动方向
        float targetAngle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
        // 平滑旋转到目标角度（避免旋转卡顿影响追踪手感）
        iconTran.rotation = targetRotation;
    }

    public void SetUp(Enemy_Necro _necro)
    {
        necro = _necro;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == null) return;

        necro.statistic.DoDamage(player.statistic);

        Destroy(gameObject);
    }

}
