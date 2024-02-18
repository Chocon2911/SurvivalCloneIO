using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : HuyMonoBehaviour
{
    [SerializeField] protected SpawnEnemy spawnEnemy;
    public SpawnEnemy SpawnEnemy => spawnEnemy;

    [SerializeField] protected EnemySpawnPoint enemySpawnPoint;
    public EnemySpawnPoint EnemySpawnPoint => enemySpawnPoint;

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO => enemySO;

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
