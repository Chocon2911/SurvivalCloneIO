using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : HuyMonoBehaviour
{
    [SerializeField] protected FollowCameraSO followCameraSO;

    [Header("Stat")]
    [SerializeField] protected float speed;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected virtual void FixedUpdate()
    {
        this.FollowMainCamera();
    }

    //=====================================Follow==================================================
    protected virtual void FollowMainCamera()
    {
        Vector2 cameraPos = GameManager.Instance.MainCamera.transform.position;
        Vector2 currPos = transform.position;

        Vector2 newPos = Vector2.Lerp(currPos, cameraPos, this.speed);
        transform.position = newPos;
    }

    //===================================Other Func================================================
    protected virtual void DefaultStat()
    {
        if (this.followCameraSO == null) Debug.LogError(transform.name + ": No followCameraSO", transform.gameObject);
        this.speed = this.followCameraSO.Speed;
    }
}
