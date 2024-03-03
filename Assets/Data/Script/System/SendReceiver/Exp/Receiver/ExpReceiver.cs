using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpReceiver : HuyMonoBehaviour
{
    [SerializeField] protected ExpReceiverSO expReceiverSO;
    public ExpReceiverSO ExpReceiverSO => expReceiverSO;

    [Header("Level")]
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

    protected virtual void Update()
    {
        this.LevelUp();
    }

    //========================================Public===============================================
    public virtual void RaiseExp(int expAmount)
    {
        this.currExpAmount += expAmount;
    }

    //========================================Update===============================================
    protected virtual void LevelUp()
    {
        if (this.currLevel >= this.exp2LevelUps.Count) return;
        if (this.currExpAmount < this.exp2LevelUps[this.currLevel]) return;
        this.currLevel++;
        Debug.Log(transform.name + ": LevelUp, currLevel " + this.currLevel, transform.gameObject);
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
