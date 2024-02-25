using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpReceiver : HuyMonoBehaviour
{
    [SerializeField] protected ExpReceiverSO expReceiverSO;
    public ExpReceiverSO ExpReceiverSO => expReceiverSO;

    [Header("Stat")]
    [SerializeField] protected int currExpAmount;
    public int CurrExpAmount => currExpAmount;

    [SerializeField] protected int currLevel;
    public int CurrLevel => currLevel;

    [SerializeField] protected List<int> exp2LevelUps;
    public List<int> Exp2LevelUps => exp2LevelUps;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //========================================Public===============================================
    public virtual void RaiseExp(int expAmount)
    {
        this.currExpAmount += expAmount;
        Debug.Log(transform.name + ": RaiseExp + " + expAmount, transform.gameObject);
    }

    //======================================Other Func=============================================
    protected virtual void DefaultStat()
    {
        if (this.expReceiverSO == null) Debug.LogError(transform.name + ": ExpReceiverSO is null", transform.gameObject);
        this.currLevel = this.expReceiverSO.CurrLevel;
        this.exp2LevelUps = this.expReceiverSO?.Exp2LevelUps;
        this.currExpAmount = 0;
    }
}
