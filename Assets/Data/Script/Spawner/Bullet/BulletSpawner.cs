using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    [SerializeField] protected string bulletOne = "Bullet_1";
    public string BulletOne => bulletOne;

    [SerializeField] protected string bulletTwo = "Bullet_2";
    public string BulletTwo => bulletTwo;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one instance exists at a time", transform.gameObject);
        else instance = this;
    }
}
