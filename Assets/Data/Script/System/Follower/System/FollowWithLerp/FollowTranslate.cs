using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTranslate : HuyMonoBehaviour
{
    [SerializeField] protected float speed;
    public float Speed => speed;

    [SerializeField] protected float zPos;
    public float ZPos => zPos;

    protected virtual void FixedUpdate()
    {
        this.CanFollow();
    }

    //======================================Follow=================================================
    protected virtual void FollowTarget(Vector3 targetPos)
    {
        if (!this.CanFollow()) return;
        Vector3 currPos = transform.parent.position;

        Vector3 newPos = Vector2.Lerp(currPos, targetPos, speed);
        newPos += (Vector3.forward * this.zPos);
        transform.parent.position = newPos;
    }

    protected abstract bool CanFollow();
}