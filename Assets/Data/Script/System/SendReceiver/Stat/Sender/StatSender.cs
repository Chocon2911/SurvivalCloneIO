using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSender : HuyMonoBehaviour
{
    [SerializeField] protected StatSenderSO statSenderSO;
    [SerializeField] protected ExpReceiver expReceiver;

    [Header("Stat")]
    [SerializeField] protected StatReceiver statReceiver;

    [SerializeField] protected List<string> canSendTags;
    public List<string> CanSendTags => canSendTags;

    [Header("Additional")]
    [SerializeField] protected float additionalDamage;
    public float AdditionalDamage => additionalDamage;

    [SerializeField] protected float additionalMoveSpeed;
    public float AdditionalMoveSpeed => additionalMoveSpeed;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExpReceiver();
    }

    protected virtual void FixedUpdate()
    {
        this.RaiseAttributeByLevel();
    }

    //=====================================Load Component==========================================
    protected virtual void LoadExpReceiver()
    {
        if (this.expReceiver != null) return;
        this.expReceiver = transform.parent.Find("ExpReceiver").GetComponent<ExpReceiver>();
        Debug.Log(transform.name + ": LoadExpReceiver", transform.gameObject);
    }    

    //=========================================Public==============================================
    public virtual void SendStat(Transform target)
    {
        foreach (string tag in this.canSendTags)
        {
            if (target.gameObject.tag == tag) this.LoadStatReceiver(target);
        }

        if (this.statReceiver == null) Debug.LogError(": StatReceiver is null", transform.gameObject);
        this.statReceiver.ReceiveStat(this.additionalDamage, this.additionalMoveSpeed);
        this.statReceiver = null;
    }

    //==========================================Stat===============================================
    protected virtual void RaiseAttributeByLevel()
    {
        this.additionalDamage = this.expReceiver.CurrLevel -1;
        this.additionalMoveSpeed = this.expReceiver.CurrLevel -1;
    }

    //=======================================Other Func============================================
    protected virtual void DefaultStat()
    {
        if (this.statSenderSO == null) Debug.LogError(transform.name + ": No StatSenderSO", transform.gameObject);
        this.canSendTags = this.statSenderSO.CanSendTags;
        this.statReceiver = null;
        this.additionalDamage = this.statSenderSO.AdditionalDamage;
        this.additionalMoveSpeed = this.statSenderSO.AdditionalMoveSpeed;
    }

    protected virtual void LoadStatReceiver(Transform target)
    {
        this.statReceiver = target.Find("StatReceiver").GetComponent<StatReceiver>();
    }
}
