using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjStat : CharacterStat
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjManager();
    }

    //======================================Load Component==========================================
    protected virtual void LoadPlayerObjManager()
    {
        if (this.playerObjManager != null) return;
        this.playerObjManager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": LoadPlayerObjManager", transform.gameObject);
    }

    //=======================================Default Stat===========================================
    protected virtual void DefaultStat()
    {
        if (this.playerObjManager == null) Debug.LogError(transform.name + ": PlayerObjManager is null", transform.gameObject);
        //Stat
        this.maxHealth = this.playerObjManager.PlayerObjSO.Hp;
        this.health = this.maxHealth;

        //Attack
        this.damage = this.playerObjManager.PlayerObjSO.Damge;
        this.attackCooldown = this.playerObjManager.PlayerObjSO.AttackCooldown;
        this.attackCharge = this.playerObjManager.PlayerObjSO.AttackCharge;

        //Move
        this.moveSpeed = this.playerObjManager.PlayerObjSO.MoveSpeed;
        this.dashSpeed = this.playerObjManager.PlayerObjSO.DashSpeed;
        this.dashCooldown = this.playerObjManager.PlayerObjSO.DashCooldown;
        this.dashInterval = this.playerObjManager.PlayerObjSO.DashInterval;
    }
}
