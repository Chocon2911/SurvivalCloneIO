using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjStat : HuyMonoBehaviour
{
    [Header("Stat")]
    [SerializeField] protected float health;
    public float Health => health;

    [SerializeField] protected float existTime;
    public float ExistTime => existTime;

    [SerializeField] protected float despawnDistance;
    public float DespawnDistance => despawnDistance;

    [Header("Attack")]
    [SerializeField] protected float damage;
    public float Damage => damage;

    [Header("Move")]
    [SerializeField] protected float moveSpeed;
    public float MoveSpeed => moveSpeed;

    //==========================================public=============================================
    //===========================================Stat==============================================
    //Health
    public virtual void AddHealth(float health)
    {
        this.health += health;
    }
    public virtual void AddHealth(float health, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddHealthTime(health, time));
    }

    public virtual void AddHealthMultiplier(float healthMultiplier)
    {
        this.health *= healthMultiplier;
    }
    public virtual void AddHealthMultiplier(float healthMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(AddHealthTime(healthMultiplier, time));
    }

    //ExistTime
    public virtual void AddExistTime(float existTime)
    {
        this.existTime += existTime;
    }
    public virtual void AddExistTime(float existTime, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddExistTimeTime(existTime, time));
    }

    public virtual void AddExistTimeMultiplier(float existTimeMultiplier)
    {
        this.existTime *= existTimeMultiplier;
    }
    public virtual void AddExistTimeMultiplier(float existTimeMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddExistTimeMultiplierTime(existTimeMultiplier, time));
    }

    //DespawnDistance
    public virtual void AddDespawnDistance(float despawnDistance)
    {
        this.despawnDistance += despawnDistance;
    }
    public virtual void AddDespawnDistance(float despawnDistance, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDespawnDistanceTime(despawnDistance, time));
    }

    public virtual void AddDespawnDistanceMultiplier(float despawnDistanceMultiplier)
    {
        this.despawnDistance *= despawnDistanceMultiplier;
    }
    public virtual void AddDespawnDistanceMultiplier(float despawnDistanceMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDespawnDistanceMultiplierTime(despawnDistanceMultiplier, time));
    }

    //============================================Time=============================================
    //============================================Stat=============================================
    //Health
    protected virtual IEnumerator AddHealthTime(float health, float time)
    {
        this.health += health;
        yield return new WaitForSeconds(time);
        this.health -= health;
    }

    protected virtual IEnumerator AddHealthMultiplierTime(float healthMultiplier, float time)
    {
        this.health *= healthMultiplier;
        yield return new WaitForSeconds(time);
        this.health /= healthMultiplier;
    }

    //ExistTime
    protected virtual IEnumerator AddExistTimeTime(float existTime, float time)
    {
        this.existTime += existTime;
        yield return new WaitForSeconds(time);
        this.existTime -= existTime;
    }

    protected virtual IEnumerator AddExistTimeMultiplierTime(float existTimeMultiplier, float time)
    {
        this.existTime *= existTimeMultiplier;
        yield return new WaitForSeconds(time);
        this.existTime /= existTimeMultiplier;
    }

    //DespawnDistance
    protected virtual IEnumerator AddDespawnDistanceTime(float despawnDistance, float time)
    {
        this.despawnDistance += despawnDistance;
        yield return new WaitForSeconds(time);
        this.despawnDistance -= despawnDistance;
    }

    protected virtual IEnumerator AddDespawnDistanceMultiplierTime(float despawnDistanceMultiplier, float time)
    {
        this.despawnDistance *= despawnDistanceMultiplier;
        yield return new WaitForSeconds(time);
        this.despawnDistance /= despawnDistanceMultiplier;
    }
}
