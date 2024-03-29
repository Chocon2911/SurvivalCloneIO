using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjDespawnByHealth : Despawner
{
    [SerializeField] protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
    }

    //===================================Load Component============================================
    protected virtual void LoadEnemyObjManager()
    {
        if (this.enemyObjManager != null) return;
        this.enemyObjManager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": LoadEnemyObjManager", transform.gameObject);
    }

    //======================================Despawner==============================================
    protected override void CheckCanDespawn()
    {
        this.canDespawn = this.enemyObjManager.EnemyObjDropExp.IsDropped;
    }

    protected override void DespawnObj()
    {
        EnemySpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }
}
