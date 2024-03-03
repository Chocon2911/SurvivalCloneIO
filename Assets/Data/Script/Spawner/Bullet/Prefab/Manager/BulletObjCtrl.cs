using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletObjCtrl))]
public class BulletObjCtrl : HuyMonoBehaviour
{
    [SerializeField] protected BulletObjManager bulletObjManager;
    public BulletObjManager BulletObjManager => bulletObjManager;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjManager();
    }

    protected virtual void Update()
    {
        this.UpdateDamage();
    }

    //===================================Load Component============================================
    protected virtual void LoadBulletObjManager()
    {
        if (this.bulletObjManager != null) return;
        this.bulletObjManager = transform.GetComponent<BulletObjManager>();
        Debug.Log(transform.name + ": LoadBulletObjManager", transform.gameObject);
    }

    //=======================================Update================================================
    protected virtual void UpdateDamage()
    {
        this.bulletObjManager.DamageSender.SetDamage(this.bulletObjManager.BulletObjStat.Damage);
    }

    //======================================OtherFunc===============================================
    protected virtual void DefaultStat()
    {
        if (this.bulletObjManager == null) Debug.LogError(transform.name + ": No BulletObjManager", transform.gameObject);
        this.bulletObjManager.DamageSender.SetDamage(this.bulletObjManager.BulletObjStat.Damage);
    }

    //=======================================Collide================================================
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(string tag in this.bulletObjManager.DamageSender.CanDamageTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Debug.Log(transform.name + ": Collide with Enemy", collision.gameObject);

                Transform enemyTrans = collision.transform;
                this.bulletObjManager.DamageSender.Sender(enemyTrans);
                this.bulletObjManager.DespawnByCollide.SetIsCollide(true);

            }
        }
    }
}
