using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : HuyMonoBehaviour
{
    private static EnemyManager instance;
    public static EnemyManager Instance => instance;

    [SerializeField] protected SpawnEnemy spawnEnemy;
    public SpawnEnemy SpawnEnemy => spawnEnemy;

    [SerializeField] protected EnemySpawnPoint enemySpawnPoint;
    public EnemySpawnPoint EnemySpawnPoint => enemySpawnPoint;

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO => enemySO;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One EnemyManager exists only!", transform.gameObject);
            return;
        }
        instance = this;

        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnEnemy();
        this.LoadEnemySpawnPoint();
    }
    //=====================================Load Component==========================================
    protected virtual void LoadSpawnEnemy()
    {
        if (this.spawnEnemy != null) return;
        this.spawnEnemy = transform.Find("SpawnEnemy").GetComponent<SpawnEnemy>();
        Debug.Log(transform.name + ": LoadSpawnEnemy", transform.gameObject);
    }
    
    protected virtual void LoadEnemySpawnPoint()
    {
        if (this.enemySpawnPoint != null) return;
        this.enemySpawnPoint = transform.Find("SpawnPoints").GetComponent<EnemySpawnPoint>();
        Debug.Log(transform.name + ": LoadEnemySpawnPoint", transform.gameObject);
    }
}
