using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObjCtrl : HuyMonoBehaviour
{
    [SerializeField] protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
    }

    protected virtual void OnEnable()
    {
        this.UpdateHealth();
        this.UpdateStatSender();
    }    

    protected virtual void Update()
    {
        this.UpdateHealth();
        this.UpdateStatSender();
    }

    //======================================Load Component=========================================
    protected virtual void LoadEnemyObjManager()
    {
        if (this.enemyObjManager != null) return;
        this.enemyObjManager = transform.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": LoadEnemyObjManager", transform.gameObject);
    }

    //==========================================Update=============================================
    protected virtual void UpdateHealth()
    {
        this.enemyObjManager.EnemyObjStat.AddHealth(-this.enemyObjManager.DamageReceiver.DamageTaken);
        this.enemyObjManager.DamageReceiver.SetDamageTaken(0);
    }

    protected virtual void UpdateStatSender()
    {
        this.enemyObjManager.StatSender.SetDamage(this.enemyObjManager.EnemyObjStat.Damage);
        this.enemyObjManager.StatSender.SetMoveSpeed(this.enemyObjManager.EnemyObjStat.MoveSpeed);
    }

    //==========================================Collide============================================
    
}
