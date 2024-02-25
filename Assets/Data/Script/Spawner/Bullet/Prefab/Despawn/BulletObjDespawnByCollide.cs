using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjDespawnByCollide : Despawner
{
    [SerializeField] protected BulletObjManager bulletObjManager;
    public BulletObjManager BulletObjManager => bulletObjManager;

    [SerializeField] protected bool isCollide;
    public bool IsCollide => isCollide;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjManager();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.SetIsCollide(false);
    }

    //=================================Load Component==============================================
    protected virtual void LoadBulletObjManager()
    {
        if (this.bulletObjManager != null) return;
        this.bulletObjManager = transform.parent.GetComponent<BulletObjManager>();
        Debug.Log(transform.name + ": LoadBulletObjManager", transform.gameObject);
    }

    //=====================================Despawner===============================================
    protected override void CheckCanDespawn()
    {
        if (!this.isCollide) return;
        this.canDespawn = true;
    }

    protected override IEnumerator DespawnObj()
    {
        yield return new WaitForSeconds(1);
        BulletSpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }

    //=======================================Setter================================================
    public virtual void SetIsCollide(bool isCollide)
    {
        this.isCollide = isCollide;
    }
}
