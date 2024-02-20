using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ExpObjManager : HuyMonoBehaviour
{
    [SerializeField] protected ExpObjCtrl expObjCtrl;
    public ExpObjCtrl ExpObjCtrl => expObjCtrl;

    [SerializeField] protected ExpObjFollowPlayer expObjFollowPlayer;
    public ExpObjFollowPlayer ExpFollowPlayer => expObjFollowPlayer;

    [SerializeField] protected CircleCollider2D detectZone;
    public CircleCollider2D DetectZone => detectZone;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExpObjCtrl();
        this.LoadExpObjFollowPlayer();
        this.LoadDetectZone();
    }

    //=======================================Load Component========================================
    protected virtual void LoadExpObjFollowPlayer()
    {
        if (this.expObjFollowPlayer != null) return;
        this.expObjFollowPlayer = transform.Find("Movement").GetComponent<ExpObjFollowPlayer>();
        Debug.Log(transform.name + ": LoadExpObjFollowPlayer", transform.gameObject);
    }

    protected virtual void LoadExpObjCtrl()
    {
        if (this.expObjCtrl != null) return;
        this.expObjCtrl = transform.GetComponent<ExpObjCtrl>();
        Debug.Log(transform.name + ": LoadExpObjCtrl", transform.gameObject);
    }

    protected virtual void LoadDetectZone()
    {
        if (this.detectZone != null) return;
        this.detectZone = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": LoadDetectZone", transform.gameObject);
    }
}
