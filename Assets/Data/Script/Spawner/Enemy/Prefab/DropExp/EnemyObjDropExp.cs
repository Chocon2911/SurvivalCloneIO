using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjDropExp : HuyMonoBehaviour
{
    [SerializeField] protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
    }

    protected virtual void Update()
    {
        this.DropExp();
    }

    //======================================Load Component==================================
    protected virtual void LoadEnemyObjManager()
    {
        if (this.enemyObjManager != null) return;
        this.enemyObjManager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": LoadEnemyObjManager", transform.gameObject);
    }

    //=========================================Drop Exp=====================================
    protected virtual void DropExp()
    {
        if (!this.enemyObjManager.DamageReceiver.IsDeath) return;
        Vector2 spawnPos = transform.parent.position;
        Quaternion spawnRot = Quaternion.Euler(0, 0, 0);
        Transform newPrefab = ExpSpawner.Instance.Spawn(ExpSpawner.Instance.ExpOne, spawnPos, spawnRot);
        if (newPrefab == null) return;
        newPrefab.gameObject.SetActive(true);
        Debug.Log(transform.name + ": Spawn Exp", transform.gameObject);
    }
}
