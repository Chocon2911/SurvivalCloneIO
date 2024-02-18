using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjFly : StraightFly
{
    [SerializeField] protected BulletObjManager bulletObjManager;
    public BulletObjManager BulletObjManager => bulletObjManager;

    protected virtual void OnEnable()
    {
        this.Fly(transform.parent.eulerAngles.z, this.bulletObjManager.Rb);
        this.BaseFlySpeed();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjManager();
        this.BaseFlySpeed();
    }

    //=======================================Load Component========================================
    protected virtual void LoadBulletObjManager()
    {
        if (this.bulletObjManager != null) return;
        this.bulletObjManager = transform.parent.GetComponent<BulletObjManager>();
        Debug.Log(transform.name + ": LoadBulletObjManager");
    }

    protected virtual void BaseFlySpeed()
    {
        this.flySpeed = this.bulletObjManager.BulletObjSO.MoveSpeed;
        Debug.Log(transform.name + ": BaseFLySpeed", transform.gameObject);
    }

    //==========================================public=============================================
    public void LevelUp(float index)
    {
        this.flySpeed += index;
        Debug.Log(transform.name + ": flySpeed " + index, transform.gameObject);
        this.Fly(transform.parent.eulerAngles.z, this.bulletObjManager.Rb);
    }
}
