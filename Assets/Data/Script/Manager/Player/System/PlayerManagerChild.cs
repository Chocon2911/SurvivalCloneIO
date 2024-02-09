using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerManagerChild : HuyMonoBehaviour
{
    [SerializeField] protected PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
    }

    //====================================Load Component===========================================
    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = transform.parent.GetComponent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }
}
