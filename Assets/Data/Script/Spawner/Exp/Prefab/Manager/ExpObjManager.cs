using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ExpObjManager : HuyMonoBehaviour
{
    [SerializeField] protected CircleCollider2D bodyCollider;
    public CircleCollider2D BodyCollider => bodyCollider;

    [SerializeField] protected ExpObjCtrl expObjCtrl;
    public ExpObjCtrl ExpObjCtrl => expObjCtrl;

    [SerializeField] protected ExpSender expSender;
    public ExpSender ExpSender => expSender;

    [SerializeField] protected ExpObjSO expObjSO;
    public ExpObjSO ExpObjSO => expObjSO;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollider();
        this.LoadExpObjCtrl();
        this.LoadExpSender();
    }

    //=====================================Load Component==========================================
    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCollider != null) return;
        this.bodyCollider = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    protected virtual void LoadExpObjCtrl()
    {
        if (this.expObjCtrl != null) return;
        this.expObjCtrl = transform.GetComponent<ExpObjCtrl>();
        Debug.Log(transform.name + ": LoadExpObjCtrl", transform.gameObject);
    }

    protected virtual void LoadExpSender()
    {
        if (this.expSender != null) return;
        this.expSender = transform.Find("ExpSender").GetComponent<ExpSender>();
        Debug.Log(transform.name + ": LoadExpSender", transform.gameObject);
    }

    //======================================Other Func=============================================
    protected virtual void DefaultStat()
    {
        if (this.expObjSO == null) Debug.LogError(transform.name + ": ExpObjSO is null", transform.gameObject);
        this.bodyCollider.radius = this.expObjSO.BodyCollideRadius;
        this.bodyCollider.isTrigger = true;
    }
}
