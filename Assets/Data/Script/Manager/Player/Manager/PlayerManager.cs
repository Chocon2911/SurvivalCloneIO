using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : HuyMonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance;

    [SerializeField] protected PlayerSpawnObj playerSpawnObj;
    public PlayerSpawnObj PlayerSpawnObj => playerSpawnObj;

    [SerializeField] protected PlayerSpawnPoint playerSpawnPoint;
    public PlayerSpawnPoint PlayerSpawnPoint => playerSpawnPoint;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only one instance exist at a time", transform.gameObject);
        else instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerSpawnObj();
        this.LoadPlayerSpawnPoint();
    }

    //==================================Load Component=============================================
    protected virtual void LoadPlayerSpawnObj()
    {
        if (this.playerSpawnObj != null) return;
        this.playerSpawnObj = transform.Find("SpawnPlayer").GetComponent<PlayerSpawnObj>();
        Debug.Log(transform.name + ": LoadPlayerSpawnObj", transform.gameObject);
    }

    protected virtual void LoadPlayerSpawnPoint()
    {
        if (this.playerSpawnPoint != null) return;
        this.playerSpawnPoint = transform.Find("SpawnPoints").GetComponent<PlayerSpawnPoint>();
        Debug.Log(transform.name + ": LoadPlayerSpawnPoint", transform.gameObject);
    }
}
