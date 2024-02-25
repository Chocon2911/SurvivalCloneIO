using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : HuyMonoBehaviour
{
    [SerializeField] protected EnemyManager enemyManager;
    public EnemyManager EnemyManager => enemyManager;

    private Transform randomPoint;

    [Header("Stat")]
    [SerializeField] protected int currLevel;
    [SerializeField] protected int spawnAmount;
    [SerializeField] protected int maxEnemy;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyManager();
    }

    protected virtual void FixedUpdate()
    {
        this.UpdateStat();
        this.CanSpawn();
        this.Spawn();
    }

    //======================================Load Component=========================================
    protected virtual void LoadEnemyManager()
    {
        if (this.enemyManager != null) return;
        this.enemyManager = transform.parent.GetComponent<EnemyManager>();
        Debug.Log(transform.name + ": LoadEnemyManager", transform.gameObject);
    }

    //==========================================Checker============================================
    protected virtual bool CanSpawn()
    {
        if (this.currLevel >= LevelManager.Instance.LevelByTime.CurrentLevel) return false;
        return true;
    }

    //==========================================Spawn==============================================
    protected virtual void Spawn()
    {
        if (!this.CanSpawn()) return;

        for (int i = 0; i < this.spawnAmount; i++)
        { 
            this.GetRandomPoint();
            Transform newPrefab = EnemySpawner.Instance.Spawn(EnemySpawner.Instance.EnemyOne, this.SpawnPos(), this.SpawnRot());

            if (newPrefab == null) return;
            newPrefab.gameObject.SetActive(true);
        }
        this.currLevel += 1;
    }

    protected virtual Vector2 SpawnPos()
    {
        Vector2 spawnPos = this.randomPoint.position;
        return spawnPos;
    }

    protected virtual Quaternion SpawnRot()
    {
        Quaternion spawnRot = this.randomPoint.rotation;
        return spawnRot;
    }

    //========================================Other Func===========================================
    protected virtual void GetRandomPoint()
    {
        this.randomPoint = this.enemyManager.EnemySpawnPoint.GetRandSpawnPoint();
    }

    //==========================================Default============================================
    protected virtual void DefaultStat()
    {
        if (this.enemyManager.EnemySO == null || this.enemyManager == null) Debug.LogError(transform.name + ": No EnemyManger or SO", transform.gameObject);
        this.currLevel = 0;
        this.maxEnemy = this.enemyManager.EnemySO.MaxEnemy;
    }

    protected virtual void UpdateStat()
    {
        if (this.enemyManager.EnemySO == null || this.enemyManager == null) Debug.LogError(transform.name + ": No EnemyManger or SO", transform.gameObject);
        this.spawnAmount = LevelManager.Instance.LevelByTime.EnemySpawnAmount;
    }
}
