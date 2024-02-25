using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    private static ItemSpawner instance;
    public static ItemSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One ItemSpawner Only", transform.gameObject);
            return;
        }
        instance = this;

        base.Awake();
    }
}
