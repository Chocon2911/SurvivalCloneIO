using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyObjShoot : HuyMonoBehaviour
{
    [SerializeField] protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    [SerializeField] protected CircleCollider2D shootRange;

    [Header("Stat")]
    [SerializeField] protected float shootPointRadius = 1f;
    [SerializeField] protected float shootCooldown;
    [SerializeField] protected float shootCooldownTimer;
    [SerializeField] protected float shootCharge;
    [SerializeField] protected float shootChargeTimer;
    [SerializeField] protected bool canShoot; public bool CanShoot => canShoot;
    [SerializeField] protected bool isShooting; public bool IsShooting => isShooting;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
        this.LoadShootRange();
    }

    protected virtual void Update()
    {
        this.CheckCanShoot();
        this.CheckIsShooting();
        this.Shoot();
    }

    //====================================Load Component===========================================
    protected virtual void LoadEnemyObjManager()
    {
        if (this.enemyObjManager != null) return;
        this.enemyObjManager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": LoadEnemyObjManager", transform.gameObject);
    }

    protected virtual void LoadShootRange()
    {
        if (this.shootRange != null) return;
        this.shootRange = transform.GetComponent<CircleCollider2D>();
        this.shootRange.isTrigger = true;
        Debug.Log(transform.name + ": LoadShootRange", transform.gameObject);
    }

    //=====================================Check Bool==============================================
    protected virtual bool CheckCanShoot()
    {
        if (this.shootCooldownTimer < this.shootCooldown && !this.isShooting) this.shootCooldownTimer += Time.deltaTime;
        this.canShoot = this.shootCooldownTimer >= this.shootCooldown;
        return this.canShoot;
    }

    protected virtual bool CheckIsShooting()
    {
        if (this.shootChargeTimer < this.shootCharge) this.shootChargeTimer += Time.deltaTime;
        this.isShooting = this.shootChargeTimer < this.shootCharge;
        return this.isShooting;
    }

    //========================================Shoot================================================
    protected virtual void Shoot()
    {
        if (!this.canShoot || this.isShooting || this.enemyObjManager == null) return;
        StartCoroutine(this.Shooting());
    }

    protected virtual IEnumerator Shooting()
    {
        this.shootChargeTimer = 0;
        this.shootCooldownTimer = 0;
        yield return new WaitForSeconds(this.shootCharge);

        Transform newPrefab = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.BulletOne, this.SpawnPos(), this.SpawnRot());
        if (newPrefab == null) yield break;
        newPrefab.gameObject.SetActive(true);
        Debug.Log(transform.name + ": Shooting", transform.gameObject);
    }

    //=========================================Spawn===============================================
    protected virtual Vector2 SpawnPos()
    {
        Vector2 dir = this.GetDir2Player();
        Vector2 transPos = transform.parent.position;
        Vector2 spawnPos = dir * this.shootPointRadius + transPos;
        return spawnPos;
    }

    protected virtual Quaternion SpawnRot()
    {
        Vector2 dir = this.GetDir2Player();
        float zRot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion spawnRot = Quaternion.Euler(0, 0, zRot);
        return spawnRot;
    }

    //======================================Default Stat===========================================
    protected virtual void DefaultStat()
    {
        this.shootCooldown = this.enemyObjManager.EnemyObjSO.ShootCooldown;
        this.shootCharge = this.enemyObjManager.EnemyObjSO.ShootCharge;
        this.shootPointRadius = this.shootRange.radius;
    }

    //========================================Other Func===========================================
    protected virtual Vector2 GetDir2Player()
    {
        Vector2 closestPlayerPos = this.enemyObjManager.ClosestActivePlayer.position;
        Vector2 transPos = transform.parent.position;
        Vector2 dir = closestPlayerPos - transPos;
        return dir.normalized;
    }
}
