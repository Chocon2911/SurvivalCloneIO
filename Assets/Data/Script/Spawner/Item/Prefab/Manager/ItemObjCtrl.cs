using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjCtrl : HuyMonoBehaviour
{
    [SerializeField] protected ItemObjManager itemObjManager;
    public ItemObjManager ItemObjManager => itemObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemObjManager();
    }

    //==========================================Load Component=====================================
    protected virtual void LoadItemObjManager()
    {
        if (this.itemObjManager != null) return;
        this.itemObjManager = transform.GetComponent<ItemObjManager>();
        Debug.Log(transform.name + ": LoadItemObjManager", transform.gameObject);
    }
}
