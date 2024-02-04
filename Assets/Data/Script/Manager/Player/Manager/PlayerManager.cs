using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : HuyMonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance;

    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Debug.LogWarning("Only one instance exist at a time", transform.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    //=====================================Load Component==========================================
    public virtual void LoadPlayerObjManager(PlayerObjManager playerObjManager)
    {
        this.playerObjManager = playerObjManager;
        Debug.Log(transform.name + ": LoadPlayerObjManager", transform.gameObject);
    }
}
