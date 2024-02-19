using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Follower : HuyMonoBehaviour
{
    protected virtual void Update()
    {
        this.CanFollow();
    }

    protected virtual Vector2 Move2TargetVelocity(Transform target, float speed)
    {
        if (!this.CanFollow() || target == null) return Vector2.zero;
        Vector2 targetPos = target.position;
        Vector2 objPos = transform.parent.position;
        Vector2 dir = targetPos - objPos;
        return dir.normalized * speed;
    }

    protected abstract bool CanFollow();
}
