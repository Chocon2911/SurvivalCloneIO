using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class BulletObjManager : HuyMonoBehaviour
{
    [SerializeField] protected BulletObjCtrl bulletObjCtrl;
    public BulletObjCtrl BulletObjCtrl => bulletObjCtrl;

    [SerializeField] protected BulletObjFly bulletObjFly;
    public BulletObjFly BulletObjFly => bulletObjFly;

    [SerializeField] protected BulletObjDespawnByDistance despawnByDistance;
    public BulletObjDespawnByDistance DespawnByDistance => despawnByDistance;

    [SerializeField] protected BulletObjDespawnByCollide despawnByCollide;
    public BulletObjDespawnByCollide DespawnByCollide => despawnByCollide;

    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected StatReceiver statReceiver;
    public StatReceiver StatReceiver => statReceiver;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected CapsuleCollider2D bodyCollider;
    public CapsuleCollider2D BodyCollider => bodyCollider;

    [SerializeField] protected BulletObjSO bulletObjSO;
    public BulletObjSO BulletObjSO => bulletObjSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjCtrl();
        this.LoadBulletObjFly();
        this.LoadDespawnByDistance();
        this.LoadDespawnByCollide();
        this.LoadDamageSender();
        this.LoadStatReceiver();
        this.LoadRigidbody();
        this.LoadBodyCollider();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.DefaultRigidbody();
        this.DefaultBodyCollider();
    }

    //===================================Load Component============================================
    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCollider != null) return;
        this.bodyCollider = transform.GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadBodyCollider");
    }

    protected virtual void LoadBulletObjCtrl()
    {
        if (this.bulletObjCtrl != null) return;
        this.bulletObjCtrl = transform.GetComponent<BulletObjCtrl>();
        Debug.Log(transform.name + ": loadBulletObjCtrl", transform.gameObject);
    }

    protected virtual void LoadBulletObjFly()
    {
        if (this.bulletObjFly != null) return;
        this.bulletObjFly = transform.Find("Movement").GetComponent<BulletObjFly>();
        Debug.Log(transform.name + ": LoadBulletObjFly", transform.gameObject);
    }

    protected virtual void LoadDespawnByCollide()
    {
        if (this.despawnByCollide != null) return;
        this.despawnByCollide = transform.Find("Despawn").GetComponent<BulletObjDespawnByCollide>();
        Debug.Log(transform.name + ": LoadDespawnByCollide", transform.gameObject);
    }

    protected virtual void LoadDespawnByDistance()
    {
        if (this.despawnByDistance != null) return;
        this.despawnByDistance = transform.Find("Despawn").GetComponent<BulletObjDespawnByDistance>();
        Debug.Log(transform.name + ": LoadDespawnByDistance", transform.gameObject);
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.Find("DamageSender").GetComponent<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", transform.gameObject);
    }

    protected virtual void LoadStatReceiver()
    {
        if (this.statReceiver != null) return;
        this.statReceiver = transform.Find("StatReceiver").GetComponent<StatReceiver>();
        Debug.Log(transform.name + ": LoadStatReceiver", transform.gameObject);
    }

    //===================================Reset Value===============================================
    protected virtual void DefaultRigidbody()
    {
        if (this.rb == null) Debug.LogWarning(transform.name + ": No Rigidbody", transform.gameObject);
        this.rb.isKinematic = true;
        this.rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    protected virtual void DefaultBodyCollider()
    {
        if (this.bodyCollider == null) Debug.LogWarning(transform.name + ": No BodyCollider", transform.gameObject);
        this.bodyCollider.isTrigger = true;
        this.bodyCollider.direction = CapsuleDirection2D.Horizontal;
    }
}
