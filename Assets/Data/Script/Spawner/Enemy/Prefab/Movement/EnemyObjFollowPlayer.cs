using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjFollowPlayer : Follower
{
    [SerializeField] protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    [Header("Stat")]
    [SerializeField] protected float moveSpeed = 0;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
    }

    protected override void Update()
    {
        base.Update();
        this.FollowActivePlayer();
    }

    //=========================================Load Component======================================
    protected virtual void LoadEnemyObjManager()
    {
        if (this.enemyObjManager != null) return;
        this.enemyObjManager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": LoadEnemyObjManager", transform.gameObject);
    }

    //=============================================Follow==========================================
    protected override bool CanFollow()
    {
        return true;
    }

    protected virtual void FollowActivePlayer()
    {
        float moveSpeed = this.moveSpeed;
        Transform closestActivePlayer = this.enemyObjManager.ClosestActivePlayer;

        this.enemyObjManager.Rb.velocity = this.Move2Target(closestActivePlayer, moveSpeed);
    }

    //=========================================Default Stat========================================
    protected virtual void DefaultStat()
    {
        this.moveSpeed = this.enemyObjManager.EnemyObjSO.MoveSpeed;
    }
}
