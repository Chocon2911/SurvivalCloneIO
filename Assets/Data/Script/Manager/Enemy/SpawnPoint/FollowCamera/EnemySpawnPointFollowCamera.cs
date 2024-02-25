using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPointFollowCamera : FollowTranslate
{
    [SerializeField] protected EnemySpawnPoint enemySpawnPoint;
    public EnemySpawnPoint EnemySpawnPoint => enemySpawnPoint;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnPoint();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.FollowTarget(GameManager.Instance.MainCamera.transform.position);
    }

    //================================Load Component===============================
    protected virtual void LoadEnemySpawnPoint()
    {
        if (this.enemySpawnPoint != null) return;
        this.enemySpawnPoint = transform.parent.GetComponent<EnemySpawnPoint>();
        Debug.Log(transform.name + ": LoadEnemySpawnPoint", transform.gameObject);
    }

    //===================================Follower==================================
    protected override bool CanFollow()
    {
        return true;
    }

    //==================================Other Func=================================
    protected virtual void DefaultStat()
    {
        if (this.enemySpawnPoint == null) Debug.LogError(transform.name + ": no EnemySpawnPoint", transform.gameObject);
        this.speed = this.enemySpawnPoint.EnemyManager.EnemySO.FollowCameraSpeed;
    }
}
