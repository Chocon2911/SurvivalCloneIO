using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : PlayerManagerChild
{
    [SerializeField] protected List<Transform> spawnPoints;
    public List<Transform> SpawnPoints => spawnPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoints();
    }

    //====================================Load Component===========================================
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count > 0) return;
        Transform spawnPointTrans = transform;
        foreach (Transform point in spawnPointTrans)
        {
            this.spawnPoints.Add(point);
        }
        Debug.Log(transform.name + ": LoadSpawnPoints", transform.gameObject);
    }
}
