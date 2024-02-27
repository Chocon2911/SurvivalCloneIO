using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemObjFollowTarget : FollowTranslate
{
    [SerializeField] protected CircleCollider2D detectZone;
    public CircleCollider2D DetectZone => detectZone;
    
    [SerializeField] protected ItemObjManager itemObjManager;
    public ItemObjManager ItemObjManager => itemObjManager;

    [Header("Stat")]
    [SerializeField] protected Vector3 targetPos;
    public Vector3 TargetPos => targetPos;

    [SerializeField] protected List<string> canPickTags = new List<string>();
    public List<string> CanPickTags => canPickTags;

    [SerializeField] protected bool isCollide;
    public bool IsCollide => isCollide;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemObjManager();
        this.LoadDetectZone();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (this.isCollide)
        {
            this.FollowTarget(this.targetPos);
        }
    }

    //=======================================Load Component========================================
    protected virtual void LoadItemObjManager()
    {
        if (this.itemObjManager != null) return;
        this.itemObjManager = transform.parent.GetComponent<ItemObjManager>();
        Debug.Log(transform.name + ": LoadItemObjManager", transform.gameObject);
    }

    protected virtual void LoadDetectZone()
    {
        if (this.detectZone != null) return;
        this.detectZone = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": LoadDetectZone", transform.gameObject);
    }

    //===========================================Follow============================================
    protected override bool CanFollow()
    {
        return isCollide;
    }

    //===========================================Collide===========================================
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in this.canPickTags) 
        {
            if (collision.gameObject.CompareTag("tag"))
            {
                this.targetPos = collision.transform.position;
                this.isCollide = true;
            }
        }
    }

    //===========================================Other Func========================================
    protected virtual void DefaultStat()
    {
        if (this.ItemObjManager == null) Debug.LogError(transform.name + ": no ItemObjManager", transform.gameObject);
        this.isCollide = false;
        this.canPickTags = this.itemObjManager.EffectSender.CanSendTags;
        this.targetPos = Vector3.zero;
    }
}
