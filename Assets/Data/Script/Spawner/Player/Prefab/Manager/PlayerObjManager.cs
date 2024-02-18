using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerObjManager : HuyMonoBehaviour
{
    [SerializeField] protected PlayerObjCtrl playerObjCtrl;
    public PlayerObjCtrl PlayerObjCtrl => playerObjCtrl;

    [SerializeField] protected PlayerObjMovement playerObjMovement;
    public PlayerObjMovement PlayerObjMovement => playerObjMovement;

    [SerializeField] protected PlayerObjShoot playerObjShoot;
    public PlayerObjShoot PlayerObjShoot => playerObjShoot;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected BoxCollider2D bodyCollide;
    public BoxCollider2D BodyCollide => bodyCollide;

    [SerializeField] protected PlayerObjSO playerObjSO;
    public PlayerObjSO PlayerObjSO => playerObjSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjCtrl();
        this.LoadPlayerObjMovement();
        this.LoadPlayerObjShoot();
        this.LoadDamageReceiver();
        this.LoadRigidbody();
        this.LoadBodyCollide();
    }

    //==================================Load Component=============================================
    protected virtual void LoadPlayerObjCtrl()
    {
        if (this.playerObjCtrl != null) return;
        this.playerObjCtrl = transform.GetComponent<PlayerObjCtrl>();
        Debug.Log(transform.name + ": LoadPlayerObjCtrl", transform.gameObject);
    }

    protected virtual void LoadPlayerObjMovement()
    {
        if (this.playerObjMovement != null) return;
        this.playerObjMovement = transform.Find("Movement").GetComponent<PlayerObjMovement>();
        Debug.Log(transform.name + ": LoadPlayerObjMovement", transform.gameObject);
    }

    protected virtual void LoadPlayerObjShoot()
    {
        if (this.playerObjShoot != null) return;
        this.playerObjShoot = transform.Find("Shoot").GetComponent<PlayerObjShoot>();
        Debug.Log(transform.name + ": LoadPlayerShoot", transform.gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.Find("DamageReceiver").GetComponent<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", transform.gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
        this.DefaultRigidbody();
    }

    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<BoxCollider2D>();
        this.bodyCollide.isTrigger = false;
        Debug.Log(transform.name + ": LoadBodyCollide", transform.gameObject);
    }

    //===================================Other Func================================================
    protected virtual void DefaultRigidbody()
    {
        this.rb.isKinematic = false;
        this.rb.gravityScale = 0;
        this.rb.angularDrag = 0;
        this.rb.freezeRotation = true;
        this.rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Debug.Log(transform.name + ": DefaultRigidbody", transform.gameObject);
    }
}
