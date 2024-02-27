using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSender : HuyMonoBehaviour
{
    [SerializeField] protected EffectSenderSO effectSenderSO;
    public EffectSenderSO EffectSenderSO => effectSenderSO;

    [Header("Effect Manager")]
    [SerializeField] protected EffectReceiver effectReceiver;
    public EffectReceiver EffectReceiver => effectReceiver;

    [SerializeField] protected List<string> canSendTags = new List<string>();
    public List<string> CanSendTags => canSendTags;

    [Header("Additional Damage")]
    [SerializeField] protected float additionalDamage;
    public float AdditionalDamage => additionalDamage;

    [SerializeField] protected float additionalDamageTime;
    public float AdditionalDamageTime => additionalDamageTime;

    [Header("Multiplier Damage")]
    [SerializeField] protected float damageMultiplier;
    public float DamageMultiplier => damageMultiplier;

    [SerializeField] protected float damageMultiplierTime;
    public float DamageMultiplierTime => damageMultiplierTime;

    [Header("Multiplier Attack Speed")]
    [SerializeField] protected float attackSpeedMultiplier;
    public float AttackSpeedMultiplier => attackSpeedMultiplier;

    [SerializeField] protected float attackSpeedMultiplierTime;
    public float AttackSpeedMultiplierTime => attackSpeedMultiplierTime;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //===========================================public============================================
    public virtual void LoadEffectReceiver(Transform target)
    {
        if (this.effectReceiver != null)
        {
            Debug.LogError(transform.name + ": EffectReceiver is not null", transform.gameObject);
            effectReceiver = null;
        }
        this.effectReceiver = target.Find("EffectReceiver").GetComponent<EffectReceiver>();
        Debug.Log(transform.name + ": EffectReceiver", transform.gameObject);
    }

    //=========================================Other Func==========================================
    protected virtual void DefaultStat()
    {
        if (this.effectSenderSO == null) Debug.LogError(transform.name + ": No EffectSenderSO", transform.gameObject);
        //Effect Manager
        this.effectReceiver = null;
        this.canSendTags = this.effectSenderSO.CanSendTags;
        
        //Additional Damage
        this.additionalDamage = this.effectSenderSO.AdditionalDamage;
        this.additionalDamageTime = this.effectSenderSO.AdditionalDamageTime;

        //Multiplier Damage
        this.damageMultiplier = this.effectSenderSO.DamageMultiplier;
        this.damageMultiplierTime = this.effectSenderSO.DamageMultiplierTime;

        //Multiplier Attack Speed
        this.attackSpeedMultiplier = this.effectSenderSO.AttackSpeedMultiplier;
        this.attackSpeedMultiplierTime = this.effectSenderSO.AttackSpeedMultiplierTime;
    }
}
