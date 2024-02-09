using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class BulletObjManager : HuyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected CapsuleCollider2D bodyCollider;
    public CapsuleCollider2D BodyCollider => bodyCollider;

    [SerializeField] protected BulletObjFly bulletObjFly;
    public BulletObjFly BulletObjFly => bulletObjFly;

    [SerializeField] protected BulletObjSO bulletObjSO;
    public BulletObjSO BulletObjSO => bulletObjSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadBodyCollider();
        this.LoadBulletObjFly();
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

    protected virtual void LoadBulletObjFly()
    {
        if (this.bulletObjFly != null) return;
        this.bulletObjFly = transform.Find("Movement").GetComponent<BulletObjFly>();
        Debug.Log(transform.name + ": LoadBulletObjFly", transform.gameObject);
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
