using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : HuyMonoBehaviour
{
    [SerializeField] protected EnemyManager enemyManager;
    public EnemyManager EnemyManager => enemyManager;

    private Transform randomPoint;

    [Header("Stat")]
    [SerializeField] protected float spawnCooldown;
    [SerializeField] protected float spawnCooldownTimer;
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

    protected virtual void Update()
    {
        this.CanSpawn();
        this.Spawn();
    }

    protected virtual void Start()
    {
        this.Spawn();
    }

    //======================================Load Component=========================================
    protected virtual void LoadEnemyManager()
    {
        if (this.enemyManager != null) return;
        this.enemyManager = transform.parent.GetComponent<EnemyManager>();
        Debug.Log(transform.name + ": LoadEnemyManager", transform.gameObject);
    }

    //==========================================Checker===============================================
    protected virtual bool CanSpawn()
    {
        if (this.spawnCooldownTimer < this.spawnCooldown) this.spawnCooldownTimer += Time.deltaTime;
        return this.spawnCooldownTimer >= this.spawnCooldown;
    }

    //==========================================Spawn==============================================
    protected virtual void Spawn()
    {
        if (!this.CanSpawn()) return;

        for (int i = 0; i < this.spawnAmount; i++)
        { 
            this.spawnCooldownTimer = 0;
            this.GetRandomPoint();
            Transform newPrefab = EnemySpawner.Instance.Spawn(EnemySpawner.Instance.EnemyOne, this.SpawnPos(), this.SpawnRot());

            if (newPrefab == null) return;
            newPrefab.gameObject.SetActive(true);
        }
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
        this.spawnCooldown = this.enemyManager.EnemySO.Cooldown;
        this.spawnAmount = LevelManager.Instance.LevelSO.EnemySpawnAmount;
        this.maxEnemy = this.enemyManager.EnemySO.MaxEnemy;
    }
}
