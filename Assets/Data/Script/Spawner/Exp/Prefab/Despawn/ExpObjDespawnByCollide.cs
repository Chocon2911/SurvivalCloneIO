using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObjDespawnByCollide : Despawner
{
    [SerializeField] protected ExpObjManager expObjManager;
    public ExpObjManager ExpObjManager => expObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExpObjManager();
    }

    //======================================Load Component=========================================
    protected virtual void LoadExpObjManager()
    {
        if (this.expObjManager != null) return;
        this.expObjManager = transform.parent.GetComponent<ExpObjManager>();
        Debug.Log(transform.name + ": LoadExpObjManager", transform.gameObject);
    }

    //=========================================Despawn=============================================
    protected override void CheckCanDespawn()
    {
        this.canDespawn = this.expObjManager.ExpObjCtrl.IsCollide;
    }

    protected override IEnumerator DespawnObj()
    {
        yield return new WaitForSeconds(1);
        ExpSpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }
}
