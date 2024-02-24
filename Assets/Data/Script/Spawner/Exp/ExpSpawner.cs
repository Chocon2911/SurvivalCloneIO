using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawner : Spawner
{
    private static ExpSpawner instance;
    public static ExpSpawner Instance => instance;

    public string ExpOne = "Exp_1";

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One ExpSpawner Only", transform.gameObject);
            return;
        }
        instance = this;

        base.Awake();
    }
}
