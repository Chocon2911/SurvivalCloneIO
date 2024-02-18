using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSender : HuyMonoBehaviour
{
    [SerializeField] protected DamageReceiver damageReceiver;
    [SerializeField] protected DamageSenderSO damageSenderSO;

    [Header("Stat")]
    [SerializeField] protected List<string> canDamageTags; public List<string> CanDamageTags => canDamageTags;
    [SerializeField] protected float damage;
    
    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //====================================Load Component===========================================
    protected virtual void LoadDamageReceiver(Transform targetTrans)
    {
        Transform damageReceiverTrans = targetTrans.Find("DamageReceiver");
        if (damageReceiverTrans == null)
        {
            Debug.LogError(transform.name + ": " + targetTrans + " hasn't got DamageReceiver", transform.gameObject);
            Debug.LogError(targetTrans.gameObject);
            return;
        }
        
        this.damageReceiver = damageReceiverTrans.GetComponent<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", transform.gameObject);
    }

    //========================================Damage===============================================
    public virtual void Sender(Transform targetTrans)
    {
        this.LoadDamageReceiver(targetTrans);
        if (this.damageReceiver == null) Debug.LogError(transform.name + "Can't find damgeReceiver", transform.gameObject);
        this.damageReceiver.DeduceHealth(this.damage);
        this.damageReceiver = null;
        Debug.Log(transform.name, transform.gameObject);
    }

    //=======================================Other Func============================================
    protected virtual void DefaultStat()
    {
        this.canDamageTags = this.damageSenderSO.CanDamageTags;
        this.damage = this.damageSenderSO.Damage;
    }
}
