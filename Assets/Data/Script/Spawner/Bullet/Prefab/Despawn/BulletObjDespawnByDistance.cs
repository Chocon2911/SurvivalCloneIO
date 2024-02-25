using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjDespawnByDistance : DespawnByDistance
{
    [SerializeField] protected BulletObjManager bulletObjManager;
    public BulletObjManager BulletObjManager => bulletObjManager;

    protected override void OnEnable()
    {
        this.BasetStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjManager();
    }

    //======================================Load Component=========================================
    protected virtual void LoadBulletObjManager()
    {
        if (this.bulletObjManager != null) return;
        this.bulletObjManager = transform.parent.GetComponent<BulletObjManager>();
        Debug.Log(transform.name + ": LoadBulletObjManager", transform.gameObject);
    }

    //=======================================Reset Value===========================================
    protected virtual void BasetStat()
    {
        this.maxDistance = this.bulletObjManager.BulletObjSO.MaxDistance;
    }

    protected override IEnumerator DespawnObj()
    {
        yield return new WaitForSeconds(1);
        BulletSpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }
}
