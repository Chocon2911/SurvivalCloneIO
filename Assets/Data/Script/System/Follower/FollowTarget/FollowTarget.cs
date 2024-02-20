using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTarget : HuyMonoBehaviour
{
    [SerializeField] protected FollowTargetSO followTargetSO;

    [Header("Stat")]
    [SerializeField] protected float speed = 0;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected abstract bool CanFollow();

    protected virtual void Follow(Transform target)
    {

    }

    //======================================Other Func=============================================
    protected virtual void DefaultStat()
    {
        if (this.followTargetSO == null) Debug.LogError(transform.name + ": No FollowTargetSO", transform.gameObject);
        this.speed = this.followTargetSO.Speed;
    }
}
