using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjFollowPlayer : Follower
{
    [SerializeField] protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected virtual void LateUpdate()
    {
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
        float moveSpeed = this.enemyObjManager.EnemyObjStat.MoveSpeed;
        Transform closestActivePlayer = this.enemyObjManager.ClosestActivePlayer;

        this.enemyObjManager.Rb.velocity = this.Move2TargetVelocity(closestActivePlayer, moveSpeed);
    }
}
