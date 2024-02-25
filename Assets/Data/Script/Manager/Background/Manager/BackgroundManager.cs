using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : HuyMonoBehaviour
{
    [SerializeField] protected BackgroundSO backgroundSO;
    public BackgroundSO BackgroundSO => backgroundSO;

    [SerializeField] protected BackgroundFollowPlayer backgroundFollowPlayer;
    public BackgroundFollowPlayer BackgroundFollowPlayer => backgroundFollowPlayer;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBackgroundFollowPlayer();
    }

    //===============================Load Component=======================================
    protected virtual void LoadBackgroundFollowPlayer()
    {
        if (this.backgroundFollowPlayer != null) return;
        this.backgroundFollowPlayer = transform.Find("FollowCamera").GetComponent<BackgroundFollowPlayer>();
        Debug.Log(transform.name + ": LoadBackgorundFollowPlayer", transform.gameObject);
    }
}
