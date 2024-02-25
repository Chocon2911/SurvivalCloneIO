using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemObjManager : HuyMonoBehaviour
{
    [SerializeField] protected CircleCollider2D bodyCollide;
    public CircleCollider2D BodyCollide => bodyCollide;
    
    [SerializeField] protected ItemObjCtrl itemObjCtrl;
    public ItemObjCtrl ItemObjCtrl => itemObjCtrl;

    [SerializeField] protected ItemObjFollowTarget itemObjFollowTarget;
    public ItemObjFollowTarget ItemObjFollowTarget => itemObjFollowTarget;

    [SerializeField] protected EffectSender effectSender;
    public EffectSender EffectSender => effectSender;

    

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollide();
        this.LoadItemObjCtrl();
        this.LoadItemObjFollowTarget();
        this.LoadEffectSender();
    }

    //======================================Load Component=========================================
    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": LoadBodyCollide", transform.gameObject);
    }

    protected virtual void LoadItemObjCtrl()
    {
        if (this.itemObjCtrl != null) return;
        this.itemObjCtrl = transform.GetComponent<ItemObjCtrl>();
        Debug.Log(transform.name + ": LoadItemObjCtrl", transform.gameObject);
    }

    protected virtual void LoadItemObjFollowTarget()
    {
        if (this.itemObjFollowTarget != null) return;
        this.itemObjFollowTarget = transform.Find("FollowTarget").GetComponent<ItemObjFollowTarget>();
        Debug.Log(transform.name + ": LoadItemObjFollowTarget", transform.gameObject);
    }

    protected virtual void LoadEffectSender()
    {
        if (this.effectSender != null) return;
        this.effectSender = transform.Find("EffectSender").GetComponent<EffectSender>();
        Debug.Log(transform.name + ": LoadEffectSender", transform.gameObject);
    }
}
