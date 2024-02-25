using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpSender : HuyMonoBehaviour
{
    [SerializeField] protected ExpSenderSO expSenderSO;
    public ExpSenderSO ExpSenderSO => expSenderSO;

    protected ExpReceiver expReceiver;

    [Header("Stat")]
    [SerializeField] protected List<string> canPickUpTags = new List<string>();
    public List<string> CanPickUpTags => canPickUpTags;

    [SerializeField] protected int expAmount;
    public int ExpAmount => expAmount;

    [SerializeField] protected bool isPickUp;
    public bool IsPickUp => isPickUp;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //=======================================public================================================
    public virtual void SendExp()
    {
        if (this.expReceiver == null) Debug.LogError(transform.name + ": ExpReceiver is null", transform.gameObject);
        this.expReceiver.RaiseExp(this.expAmount);
        this.isPickUp = true;
    }
    
    public virtual void LoadExpReceiver(Transform target)
    {
        this.expReceiver = target.Find("ExpReceiver").GetComponent<ExpReceiver>();
        Debug.Log(transform.name + ": LoadExpReceiver from" + target.name, transform.gameObject);
    }

    //=====================================Other Func==============================================
    protected virtual void DefaultStat()
    {
        if (this.expSenderSO == null) Debug.LogError(transform.name + ": ExpSenderSO is null", transform.gameObject);
        this.canPickUpTags = this.expSenderSO.CanPickUpTags;
        this.expAmount = this.expSenderSO.ExpAmount;
        this.isPickUp = false;
    }
}
