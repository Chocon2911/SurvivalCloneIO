using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StraightFly : HuyMonoBehaviour
{
    [SerializeField] protected float flySpeed = 5f;

    protected virtual void Fly(float zRot, Rigidbody2D rb)
    {
        Vector2 dir = this.GetDir(zRot);

        Vector2 velocity = dir * flySpeed;
        rb.velocity = velocity;
    }

    protected virtual Vector2 GetDir(float angle)
    {
        float xDir = Mathf.Cos(Mathf.Deg2Rad * angle);
        float yDir = Mathf.Sin(Mathf.Deg2Rad * angle);

        Vector2 dir = new Vector2(xDir, yDir).normalized;
        return dir;
    }
}
