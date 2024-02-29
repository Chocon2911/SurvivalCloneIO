using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerObjManager))]
public class PlayerObjCtrl : HuyMonoBehaviour
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjManager();
    }

    protected virtual void Update()
    {
        this.playerObjManager.PlayerObjStat.AddHealth(-this.playerObjManager.DamageReceiver.DamageTaken);
        this.playerObjManager.DamageReceiver.SetDamageTaken(0);
    }

    //======================================Load Component=========================================
    protected virtual void LoadPlayerObjManager()
    {
        if (this.playerObjManager != null) return;
        this.playerObjManager = transform.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": LoadPlayerObjManager", transform.gameObject);
    }
}
