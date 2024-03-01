using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSender : HuyMonoBehaviour
{
    [SerializeField] protected StatSenderSO statSenderSO;

    [Header("Stat")]
    [SerializeField] protected StatReceiver statReceiver;

    [SerializeField] protected List<string> canSendTags;
    public List<string> CanSendTags => canSendTags;

    [Header("Additional")]
    [SerializeField] protected float damage;
    public float Damage => damage;

    [SerializeField] protected float moveSpeed;
    public float MoveSpeed => moveSpeed;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    //=========================================Public==============================================
    public virtual void SendStat(Transform target)
    {
        foreach (string tag in this.canSendTags)
        {
            if (target.gameObject.tag == tag) this.LoadStatReceiver(target);
        }

        if (this.statReceiver == null) Debug.LogError(": StatReceiver is null", transform.gameObject);
        this.statReceiver.ReceiveStat(this.damage, this.moveSpeed);
        this.statReceiver = null;
    }

    public virtual void SetDamage(float damage)
    {
        this.damage = damage;
    }
    
    public virtual void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    //=======================================Other Func============================================
    protected virtual void DefaultStat()
    {
        if (this.statSenderSO == null) Debug.LogError(transform.name + ": No StatSenderSO", transform.gameObject);
        this.canSendTags = this.statSenderSO.CanSendTags;
        this.statReceiver = null;
    }

    protected virtual void LoadStatReceiver(Transform target)
    {
        this.statReceiver = target.Find("StatReceiver").GetComponent<StatReceiver>();
    }
}
