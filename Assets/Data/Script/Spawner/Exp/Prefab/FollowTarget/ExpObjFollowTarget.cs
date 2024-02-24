using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ExpObjFollowTarget : FollowTranslate
{
    [SerializeField] protected CircleCollider2D detectZone;
    public CircleCollider2D DetectZone => detectZone;

    [SerializeField] protected ExpObjManager expObjManager;
    public ExpObjManager ExpObjManager => expObjManager;

    [Header("Stat")]
    [SerializeField] protected bool isCollide;
    public bool IsCollide => isCollide;

    [SerializeField] protected Transform target;
    public Transform Target => target;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDetectZone();
        this.loadExpObjManager();
    }

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (this.target != null)
        {
            this.FollowTarget(this.target.position);
        }
    }

    //=======================================Load Component========================================
    protected virtual void LoadDetectZone()
    {
        if (this.detectZone != null) return;
        this.detectZone = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": LoadDetectZone", transform.gameObject);
    }

    protected virtual void loadExpObjManager()
    {
        if (this.expObjManager != null) return;
        this.expObjManager = transform.parent.GetComponent<ExpObjManager>();
        Debug.Log(transform.name + ": LoadExpObjManager", transform.gameObject);
    }

    //============================================Follow===========================================
    protected override bool CanFollow()
    {
        return this.isCollide;
    }

    //===========================================Other Func========================================
    protected virtual void DefaultStat()
    {
        if (this.expObjManager == null) Debug.LogError(transform.name + ": ExpObjManager is null", transform.gameObject);
        this.speed = this.expObjManager.ExpObjSO.Speed;
        this.detectZone.isTrigger = true;
        this.detectZone.radius = this.expObjManager.ExpObjSO.DetectZoneRadius;
    }

    //============================================Collide==========================================
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in this.expObjManager.ExpSender.CanPickUpTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                this.isCollide = true;
                this.target = collision.transform;
            }
        }
    }
}
