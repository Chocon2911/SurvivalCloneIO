using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletObjStat : HuyMonoBehaviour
{
    [Header("Despawn")]
    [SerializeField] protected float despawnDistance;
    public float DespawnDistance => despawnDistance;

    [SerializeField] protected float existTime;
    public float ExistTime => existTime;

    [Header("Attack")]
    [SerializeField] protected float damage;
    public float Damage => damage;

    [Header("Move")]
    [SerializeField] protected float moveSpeed;
    public float MoveSpeed => moveSpeed;

    [Header("Bullet")]
    [SerializeField] protected BulletObjManager bulletObjManager;
    public BulletObjManager BulletObjManager => bulletObjManager;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjManager();
    }

    //===========================================Public========================================
    //===========================================Despawn=======================================
    //DespawnDistance
    public virtual void AddDespawnDistance(float value)
    {
        this.despawnDistance += value;
    }
    public virtual void AddDespawnDistance(float value, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDespawnDistanceTime(value, time));
    }

    public virtual void AddDespawnDistanceMultiplier(float value)
    {
        this.despawnDistance *= value;
    }
    public virtual void AddDespawnDistanceMultiplier(float value, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDespawnDistanceMultiplierTime(value, time));
    }

    //ExistTime
    public virtual void AddExistTime(float value)
    {
        this.existTime += value;
    }
    public virtual void AddExistTime(float value, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddExistTimeTime(value, time));   
    }

    public virtual void AddExistTimeMultiplier(float value)
    {
        this.existTime *= value;
    }
    public virtual void AddExistTimeMultplier(float value, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddExistTimeMultiplierTime(value, time));
    }

    //==========================================Attack==========================================
    //Damage
    public virtual void AddDamage(float value)
    {
        this.damage += value;
    }
    public virtual void AddDamage(float value, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDamageTime(value, time));
    }    

    public virtual void AddDamageMultiplier(float value)
    {
        this.damage *= value;
    }
    public virtual void AddDamageMultiplier(float value, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDamageMultiplierTime(value, time));
    }

    //===========================================Move===========================================
    //MoveSpeed
    public virtual void AddMoveSpeed(float value)
    {
        this.moveSpeed += value;
    }
    public virtual void AddMoveSpeed(float value, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddMoveSpeedTime(value, time));
    }

    public virtual void AddMoveSpeedMultiplier(float value)
    {
        this.moveSpeed *= value;
    }
    public virtual void AddMoveSpeedMultiplier(float value, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddMoveSpeedMultiplierTime(value, time));
    }

    //===========================================Time===========================================
    //DespawnDistance
    protected virtual IEnumerator AddDespawnDistanceTime(float value, float time)
    {
        this.despawnDistance += value;
        yield return new WaitForSeconds(time);
        this.despawnDistance -= value;
    }
    protected virtual IEnumerator AddDespawnDistanceMultiplierTime(float value, float time)
    {
        this.despawnDistance *= value;
        yield return new WaitForSeconds(time);
        this.despawnDistance /= value;
    }

    //ExistTime
    protected virtual IEnumerator AddExistTimeTime(float value, float time)
    {
        this.existTime += value;
        yield return new WaitForSeconds(time);
        this.existTime -= value;
    }
    protected virtual IEnumerator AddExistTimeMultiplierTime(float value, float time)
    {
        this.existTime *= value;
        yield return new WaitForSeconds(time);
        this.existTime /= value;
    }

    //============================================Attack=========================================
    //Damage
    protected virtual IEnumerator AddDamageTime(float value, float time)
    {
        this.damage += value;
        yield return new WaitForSeconds(time);
        this.damage -= value;
    }
    protected virtual IEnumerator AddDamageMultiplierTime(float value, float time)
    {
        this.damage *= value;
        yield return new WaitForSeconds(time);
        this.damage /= value;   
    }

    //==============================================Move==========================================
    protected virtual IEnumerator AddMoveSpeedTime(float value, float time)
    {
        this.moveSpeed += value;
        yield return new WaitForSeconds(time);
        this.moveSpeed /= value;
    }
    protected virtual IEnumerator AddMoveSpeedMultiplierTime(float value, float time)
    {
        this.moveSpeed *= value;
        yield return new WaitForSeconds(time);
        this.moveSpeed /= value;
    }
    //==========================================Load Component=====================================
    protected virtual void LoadBulletObjManager()
    {
        if (this.bulletObjManager != null) return;
        this.bulletObjManager = transform.parent.GetComponent<BulletObjManager>();
        Debug.Log(transform.name + ": LoadBulletObjManager", transform.gameObject);
    }

    //=============================================Other Func======================================
    protected virtual void DefaultStat()
    {
        if (this.bulletObjManager == null) Debug.LogError(transform.name + ": BulletObjManager is null", transform.gameObject);
        //Despawn
        this.despawnDistance = this.bulletObjManager.BulletObjSO.MaxDistance;
        this.existTime = this.bulletObjManager.BulletObjSO.ExistTime;

        //Move
        this.moveSpeed = this.bulletObjManager.BulletObjSO.MoveSpeed + this.bulletObjManager.StatReceiver.AdditionalMoveSpeed;

        //Attack
        this.damage = this.bulletObjManager.BulletObjSO.Damage + this.bulletObjManager.StatReceiver.AdditionalDamage;
    }
}
