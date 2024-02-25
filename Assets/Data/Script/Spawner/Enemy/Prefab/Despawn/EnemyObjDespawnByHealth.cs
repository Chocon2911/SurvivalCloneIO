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
        this.canDespawn = this.enemyObjManager.DamageReceiver.IsDeath;
    }

    protected override IEnumerator DespawnObj()
    {
        yield return new WaitForSeconds(1);
        EnemySpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }
}
