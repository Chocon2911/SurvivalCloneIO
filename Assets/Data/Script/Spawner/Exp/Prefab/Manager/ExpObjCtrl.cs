using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObjCtrl : HuyMonoBehaviour
{
    [SerializeField] protected ExpObjManager expObjManager;
    public ExpObjManager ExpObjManager => expObjManager;

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
        this.LoadExpObjManager();
    }

    //========================================Load Component=======================================
    protected virtual void LoadExpObjManager()
    {
        if (this.expObjManager != null) return;
        this.expObjManager = transform.GetComponent<ExpObjManager>();
        Debug.Log(transform.name + ": LoadExpObjManager", transform.gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in this.expObjManager.ExpSender.CanPickUpTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                this.expObjManager.ExpSender.LoadExpReceiver(collision.transform);
                this.expObjManager.ExpSender.SendExp();
                this.isCollide = true;
            }
        }
    }

    //===========================================Other Func=========================================
    protected virtual void DefaultStat()
    {
        this.isCollide = false;
    }
}
