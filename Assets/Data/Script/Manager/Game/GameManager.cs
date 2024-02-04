using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : HuyMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

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
}
