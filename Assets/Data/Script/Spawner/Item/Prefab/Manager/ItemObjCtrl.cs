using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjCtrl : HuyMonoBehaviour
{
    [SerializeField] protected ItemObjManager itemObjManager;
    public ItemObjManager ItemObjManager => itemObjManager;

    [Header("Stat")]
    [SerializeField] protected bool isCollide;
    public bool IsCollide => isCollide;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

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

    //==============================================Collide========================================
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in this.itemObjManager.EffectSender.CanSendTags)
        {
            if (collision.gameObject.CompareTag(tag)) this.isCollide = true;
        }
    }
    
    //==============================================Other Func=====================================
    protected virtual void DefaultStat()
    {
        if (this.itemObjManager == null) Debug.LogError(transform.name + ": No ItemObjManager", transform.gameObject);
        this.isCollide = false;
    }
}
