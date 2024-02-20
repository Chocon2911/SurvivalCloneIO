using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObjFollowPlayer : FollowTarget
{
    [SerializeField] protected ExpObjManager expObjManager;
    public ExpObjManager ExpObjManager => expObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExpObjManager();
    }

    //========================================Follower=============================================
    protected override bool CanFollow()
    {
        return true;
    }

    //======================================Load Component=========================================
    protected virtual void LoadExpObjManager()
    {
        if (this.expObjManager != null) return;
        this.expObjManager = transform.parent.GetComponent<ExpObjManager>();
    }
}
