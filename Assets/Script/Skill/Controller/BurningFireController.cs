using System.Collections.Generic;
using UnityEngine;

public class BurningFireController : MonoBehaviour
{
    [SerializeField] private float damage = 5f;
    [SerializeField] private float damageInterval = 0.4f;
    [SerializeField] private float lifeTime = 5f;

    /// <summary>所有火焰共用：当前处于至少一团火中的敌人。</summary>
    private static readonly HashSet<Enemy> enemiesInRange = new HashSet<Enemy>();
    /// <summary>敌人同时重叠的火焰数量，避免离开其中一团时被误移除。</summary>
    private static readonly Dictionary<Enemy, int> overlapCounts = new Dictionary<Enemy, int>();
    private static readonly List<BurningFireController> activeFires = new List<BurningFireController>();
    private static float sharedDamageTimer;

    private readonly HashSet<Enemy> trackedByThisFire = new HashSet<Enemy>();
    private PlayerStatistic playerStatistic;
    private float lifeTimer;

    private void OnEnable()
    {
        activeFires.Add(this);
    }

    private void OnDisable()
    {
        activeFires.Remove(this);

        // 火焰销毁时释放本实例登记的重叠
        foreach (Enemy enemy in trackedByThisFire)
        {
            DecreaseOverlap(enemy);
        }
        trackedByThisFire.Clear();
    }

    private void Start()
    {
        playerStatistic = PlayerManager.instance.player.statistic;
        lifeTimer = lifeTime;
        // 首团火立刻跳伤；后续火苗沿用共享计时，不会额外叠伤
        if (activeFires.Count == 1)
        {
            sharedDamageTimer = 0f;
        }
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
            return;
        }

        // 只由列表中第一团火负责全局跳伤，保证多火重叠不叠伤
        if (activeFires.Count == 0 || activeFires[0] != this)
        {
            return;
        }

        sharedDamageTimer -= Time.deltaTime;
        if (sharedDamageTimer <= 0f)
        {
            sharedDamageTimer = damageInterval;
            DealDamageToEnemiesInRange();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = GetEnemy(collision);
        if (enemy == null || enemy.isDead)
        {
            return;
        }

        if (trackedByThisFire.Add(enemy))
        {
            IncreaseOverlap(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy enemy = GetEnemy(collision);
        if (enemy == null)
        {
            return;
        }

        if (trackedByThisFire.Remove(enemy))
        {
            DecreaseOverlap(enemy);
        }
    }

    private static Enemy GetEnemy(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy == null)
        {
            enemy = collision.GetComponentInParent<Enemy>();
        }
        return enemy;
    }

    private static void IncreaseOverlap(Enemy enemy)
    {
        if (!overlapCounts.TryGetValue(enemy, out int count))
        {
            count = 0;
        }
        overlapCounts[enemy] = count + 1;
        enemiesInRange.Add(enemy);
    }

    private static void DecreaseOverlap(Enemy enemy)
    {
        if (!overlapCounts.TryGetValue(enemy, out int count))
        {
            return;
        }

        count--;
        if (count <= 0)
        {
            overlapCounts.Remove(enemy);
            enemiesInRange.Remove(enemy);
        }
        else
        {
            overlapCounts[enemy] = count;
        }
    }

    private void DealDamageToEnemiesInRange()
    {
        if (playerStatistic == null || enemiesInRange.Count == 0)
        {
            return;
        }

        // 先复制再遍历：死亡会关碰撞体并触发 OnTriggerExit
        List<Enemy> snapshot = new List<Enemy>(enemiesInRange);

        for (int i = 0; i < snapshot.Count; i++)
        {
            Enemy enemy = snapshot[i];
            if (enemy == null || enemy.isDead)
            {
                ClearEnemy(enemy);
                continue;
            }

            enemy.statistic.TakeMagicDamage(playerStatistic, damage);

            if (enemy == null || enemy.isDead)
            {
                ClearEnemy(enemy);
            }
        }
    }

    private static void ClearEnemy(Enemy enemy)
    {
        if (enemy == null)
        {
            return;
        }

        overlapCounts.Remove(enemy);
        enemiesInRange.Remove(enemy);
    }
}
