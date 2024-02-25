using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : FollowTranslate
{
    [SerializeField] protected CameraManager cameraManager;
    public CameraManager CameraManager => cameraManager;

    protected override void FixedUpdate()
    {
        this.FollowTarget(this.GetPlayersMidPos());
    }

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCameraManager();
    }

    //================================Load Component===============================================
    protected virtual void LoadCameraManager()
    {
        if (this.cameraManager != null) return;
        this.cameraManager = transform.parent.GetComponent<CameraManager>();
        Debug.Log(transform.name + ": LoadCameraManager", transform.gameObject);
    }

    //====================================Follow===================================================
    protected override bool CanFollow()
    {
        return true;
    }

    //====================================Player===================================================
    protected virtual Vector3 GetPlayersMidPos()
    {
        List<Transform> players = GameManager.Instance.ActivePlayers;

        Vector3 midPosition = Vector3.zero;
        foreach (Transform player in players)
        {
            Vector3 playerPos = player.position;
            midPosition += playerPos;
        }
        return midPosition;
    }

    //==================================Other Func=================================================
    protected virtual void DefaultStat()
    {
        if (this.cameraManager == null) Debug.LogError(transform.name + ": No CameraManager", transform.gameObject);
        this.speed = this.cameraManager.CameraSO.Speed;
        this.zPos = -10;
    }
}
