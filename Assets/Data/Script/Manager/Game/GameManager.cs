using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : HuyMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

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
        this.LoadMainCamera();
    }

    protected virtual void FixedUpdate()
    {
        this.DeleteDeActivePlayerObj();
    }

    //=====================================Load Component==========================================
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadMainCamera", transform.gameObject);
    }

    //=======================================public================================================
    public virtual void AddActivePlayerObj(Transform playerObj)
    {
        this.activePlayers.Add(playerObj);
        Debug.Log(transform.name + ": AddActivePlayerObj", transform.gameObject);
    }

    public virtual void DeleteDeActivePlayerObj()
    {
        List<Transform> canRemovedPlayers = new List<Transform>();
        foreach (Transform playerObj in this.activePlayers)
        {
            if (!playerObj.gameObject.activeSelf) canRemovedPlayers.Add(playerObj);
        }
        if (canRemovedPlayers == null) return;

        foreach (Transform playerObj in canRemovedPlayers)
        {
            this.activePlayers.Remove(playerObj);
        }
    }
}
