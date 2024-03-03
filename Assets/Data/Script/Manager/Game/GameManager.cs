using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : HuyMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => gameCtrl;

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => mainCamera;

    [SerializeField] protected List<Transform> activePlayers;
    public List<Transform> ActivePlayers => activePlayers;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Debug.LogError("Only one instance exist at a time", transform.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGameCtrl();
        this.LoadMainCamera();
    }

    protected virtual void Update()
    {
        this.CheckActivePlayer();
    }

    //=====================================Load Component==========================================
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadMainCamera", transform.gameObject);
    }

    protected virtual void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = transform.GetComponent<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", transform.gameObject);
    }

    //=======================================Player List===========================================
    protected virtual void CheckActivePlayer()
    {
        Transform holderTrans = PlayerSpawner.Instance.transform.Find("Holder");
        List<Transform> activePlayers = new List<Transform>();
        foreach (Transform player in holderTrans)
        {
            if (player.gameObject.activeSelf) activePlayers.Add(player);
        }

        this.activePlayers = activePlayers;
    }
}
