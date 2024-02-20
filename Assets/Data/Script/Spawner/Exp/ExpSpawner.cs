using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawner : Spawner
{
    private static ExpSpawner instance;
    public static ExpSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": Only one ExpSpawner can exists at a time", transform.gameObject);
            return;
        }
        instance = this;

        base.Awake();
    }
}
