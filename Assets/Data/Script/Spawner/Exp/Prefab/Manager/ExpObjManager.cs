using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField] protected ExpObjFollowTarget expObjFollowTarget;
    public ExpObjFollowTarget ExpObjFollowTarget => expObjFollowTarget;

    [SerializeField] protected ExpObjDespawnByCollide despawnByCollide;
    public ExpObjDespawnByCollide DespawnByCollide => despawnByCollide;

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
        this.LoadExpObjFollowTarget();
        this.LoadExpObjDespawnByCollide();
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

    protected virtual void LoadExpObjFollowTarget()
    {
        if (this.expObjFollowTarget != null) return;    
        this.expObjFollowTarget = transform.Find("FollowPlayer").GetComponent<ExpObjFollowTarget>();
        Debug.Log(transform.name + ": LoadExpObjFollowTarget", transform.gameObject);
    }

    protected virtual void LoadExpObjDespawnByCollide()
    {
        if (this.despawnByCollide != null) return;
        this.despawnByCollide = transform.Find("Despawn").GetComponent<ExpObjDespawnByCollide>();
        Debug.Log(transform.name + ": LoadExpObjDespawnByCollide", transform.gameObject);
    }

    //======================================Other Func=============================================
    protected virtual void DefaultStat()
    {
        if (this.expObjSO == null) Debug.LogError(transform.name + ": ExpObjSO is null", transform.gameObject);
        this.bodyCollider.radius = this.expObjSO.BodyCollideRadius;
        this.bodyCollider.isTrigger = true;
    }
}
