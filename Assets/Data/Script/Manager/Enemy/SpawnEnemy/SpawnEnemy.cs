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
    [SerializeField] protected bool canSpawn; 

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
        this.CheckCanSpawn();
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
    protected virtual bool CheckCanSpawn()
    {
        if (this.spawnCooldownTimer < this.spawnCooldown) this.spawnCooldownTimer += Time.deltaTime;
        this.canSpawn = this.spawnCooldownTimer >= this.spawnCooldown;
        return this.canSpawn;
    }

    //==========================================Spawn==============================================
    protected virtual void Spawn()
    {
        if (!this.canSpawn) return;

        this.spawnCooldownTimer = 0;
        this.GetRandomPoint();
        Transform newPrefab = EnemySpawner.Instance.Spawn(EnemySpawner.Instance.EnemyOne, this.SpawnPos(), this.SpawnRot());
        
        if (newPrefab == null) return;
        newPrefab.gameObject.SetActive(true);
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
        this.spawnCooldown = this.enemyManager.EnemySO.Cooldown;
    }
}
