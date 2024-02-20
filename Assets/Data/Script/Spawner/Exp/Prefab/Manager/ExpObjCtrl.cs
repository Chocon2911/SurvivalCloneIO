using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObjCtrl : HuyMonoBehaviour
{
    [SerializeField] protected ExpObjManager expObjManager;
    public ExpObjManager ExpObjManager => expObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExpObjManager();
    }

    protected virtual void LoadExpObjManager()
    {
        if (this.expObjManager != null) return;
        this.expObjManager = transform.GetComponent<ExpObjManager>();
        Debug.Log(transform.name + ": LoadExpObjManager", transform.gameObject);
    }
}
