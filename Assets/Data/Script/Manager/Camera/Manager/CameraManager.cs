using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : HuyMonoBehaviour
{
    [SerializeField] protected CameraFollowPlayer cameraFollowPlayer;
    public CameraFollowPlayer CameraFollowPlayer => cameraFollowPlayer;

    [SerializeField] protected CameraSO cameraSO;
    public CameraSO CameraSO => cameraSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCameraFollowPlayer();
    }

    protected virtual void LoadCameraFollowPlayer()
    {
        if (this.cameraFollowPlayer != null) return;
        this.cameraFollowPlayer = transform.Find("FollowPlayer").GetComponent<CameraFollowPlayer>();
        Debug.Log(transform.name + ": LoadCameraFollowPlayer", transform.gameObject);
    }
}
