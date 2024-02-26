using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDespawnByHealth : Despawner
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjManagers();
    }

    //========================================Load Component=================================================================
    protected virtual void LoadPlayerObjManagers()
    {
        if (this.playerObjManager != null) return;
        this.playerObjManager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": LoadPlayerObjManager", transform.gameObject);
    }

    //===========================================Despawner===================================================================
    protected override void DespawnObj()
    {
        PlayerSpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }

    protected override void CheckCanDespawn()
    {
        this.canDespawn = this.playerObjManager.DamageReceiver.IsDeath;
    }
}
