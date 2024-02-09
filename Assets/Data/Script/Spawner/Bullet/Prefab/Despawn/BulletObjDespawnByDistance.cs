using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjDespawnByDistance : DespawnByDistance
{
    [SerializeField] protected BulletObjManager bulletObjManager;
    public BulletObjManager BulletObjManager => bulletObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjManager();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.BastStat();
    }

    //======================================Load Component=========================================
    protected virtual void LoadBulletObjManager()
    {
        if (this.bulletObjManager != null) return;
        this.bulletObjManager = transform.parent.GetComponent<BulletObjManager>();
        Debug.Log(transform.name + ": LoadBulletObjManager", transform.gameObject);
    }

    //=======================================Reset Value===========================================
    protected virtual void BastStat()
    {
        this.maxDistance = 50f;
    }

    protected override void DespawnObj()
    {
        BulletSpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }
}
