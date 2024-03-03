using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjFly : StraightFly
{
    [SerializeField] protected BulletObjManager bulletObjManager;
    public BulletObjManager BulletObjManager => bulletObjManager;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
        this.Fly(transform.parent.eulerAngles.z, this.bulletObjManager.Rb);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjManager();
        this.DefaultStat();
    }

    //=======================================Load Component========================================
    protected virtual void LoadBulletObjManager()
    {
        if (this.bulletObjManager != null) return;
        this.bulletObjManager = transform.parent.GetComponent<BulletObjManager>();
        Debug.Log(transform.name + ": LoadBulletObjManager");
    }

    //======================================Other Func=============================================
    protected virtual void DefaultStat()
    {
        if (this.bulletObjManager == null) Debug.LogError(transform.name + ": No BulletObjManager", transform.gameObject);
        //flySpeed
        this.flySpeed = this.bulletObjManager.BulletObjStat.MoveSpeed; ;
    }
}
