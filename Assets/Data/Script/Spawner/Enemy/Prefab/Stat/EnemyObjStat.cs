using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjStat : CharacterStat
{
    [Header("Enemy")]
    [SerializeField] protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    [Header("Shoot Range")]
    [SerializeField] protected float shootPosRadius;
    public float ShootPosRadius => shootPosRadius;

    [Header("Stat")]
    [SerializeField] protected bool isDead;
    public bool IsDead => isDead;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected virtual void Update()
    {
        this.CheckIsDead();
        this.AddHealth(-this.enemyObjManager.DamageReceiver.DamageTaken);
        this.enemyObjManager.DamageReceiver.SetDamageTaken(0);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
    }

    //==========================================Checker============================================
    protected virtual void CheckIsDead()
    {
        if (this.health <= 0) this.isDead = true;
        else this.isDead = false;
    }

    //=======================================Load Component========================================
    protected virtual void LoadEnemyObjManager()
    {
        if (this.enemyObjManager != null) return;
        this.enemyObjManager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": LoadEnemyObjManager", transform.gameObject);
    }

    //=========================================Other Func==========================================
    protected virtual void DefaultStat()
    {
        if (this.enemyObjManager == null) Debug.LogError(transform.name + ": EnemyObjManager is null", transform.gameObject);
        //Stat
        this.maxHealth = this.enemyObjManager.EnemyObjSO.Health;
        this.health = this.maxHealth;

        //Attack
        this.damage = this.enemyObjManager.EnemyObjSO.Damage;
        this.attackCooldown = this.enemyObjManager.EnemyObjSO.ShootCooldown;
        this.attackCharge = this.enemyObjManager.EnemyObjSO.ShootCharge;

        //Move
        this.moveSpeed = this.enemyObjManager.EnemyObjSO.MoveSpeed;
        this.dashCooldown = 0;
        this.dashInterval = 0;
        this.dashSpeed = 0;

        //Enemy
        //Attack Range
        this.shootPosRadius = this.enemyObjManager.EnemyObjSO.ShootPosRadius;

        //Stat
        this.isDead = false;
    }
}
