using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : HuyMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => mainCamera;

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

    //=====================================Load Component==========================================
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadMainCamera", transform.gameObject);
    }
}
