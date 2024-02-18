using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    [SerializeField] protected string enemyOne = "Enemy_1";
    public string EnemyOne => enemyOne;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one instance exists at a time", transform.gameObject);
        else instance = this;
    }
}
