using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageReceiver : HuyMonoBehaviour
{
    [SerializeField] protected DamageReceiverSO damageReceiverSO;

    [Header("Stat")]
    [SerializeField] protected float health; public float Health => health;
    [SerializeField] protected bool isDeath; public bool IsDeath => isDeath;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //=======================================Checker===============================================
    protected virtual void CheckIsDeath()
    {
        if (this.health > 0) return;
        this.isDeath = true;
    }

    //========================================Damage===============================================
    public virtual void DeduceHealth(float damage)
    {
        if (this.isDeath) return;
        this.health -= damage;
        this.CheckIsDeath();
        Debug.Log(transform.name + ": " + this.health + "hp left", transform.gameObject);
    }

    //======================================Other Func=============================================
    protected virtual void DefaultStat()
    {
        if (this.damageReceiverSO == null) Debug.LogError(transform.name + ": damageReceiverSO is null", transform.gameObject);
        this.health = this.damageReceiverSO.MaxHealth;
        this.isDeath = false;
    }
}
