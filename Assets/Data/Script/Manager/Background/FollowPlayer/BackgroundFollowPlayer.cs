using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowPlayer : FollowTranslate
{
    [SerializeField] protected BackgroundManager backgrounManager;
    public BackgroundManager BackgrounManager => backgrounManager;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBackgroundManager();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.FollowTarget(GameManager.Instance.ActivePlayers[0].transform.position);
    }

    //=================================Load Component===============================
    protected virtual void LoadBackgroundManager()
    {
        if (this.backgrounManager != null) return;
        this.backgrounManager = transform.parent.GetComponent<BackgroundManager>();
        Debug.Log(transform.name + ": LoadBackgroundManager", transform.gameObject);
    }

    //====================================Follow====================================
    protected override bool CanFollow()
    {
        if (GameManager.Instance.GameCtrl.IsGameOver) return false;
        return true;
    }

    //==================================Other Func===================================
    protected virtual void DefaultStat()
    {
        if (this.backgrounManager == null) Debug.LogError(transform.name + ": backgroundManager is null", transform.gameObject);
        this.speed = this.backgrounManager.BackgroundSO.Speed;
        this.zPos = 0;
    }
}
