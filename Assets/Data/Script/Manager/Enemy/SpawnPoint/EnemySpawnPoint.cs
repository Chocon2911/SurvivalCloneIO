using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : HuyMonoBehaviour
{
    [SerializeField] protected EnemyManager enemyManager;
    public EnemyManager EnemyManager => enemyManager;

    [SerializeField] protected List<Transform> spawnPoints;
    public List<Transform> SpawnPoints => spawnPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyManager();
        this.LoadSpawnPoints();
    }

    //====================================Load Component===========================================
    protected virtual void LoadEnemyManager()
    {
        if (this.enemyManager != null) return;
        this.enemyManager = transform.parent.GetComponent<EnemyManager>();
        Debug.Log(transform.name + ": LoadEnemyManager", transform.gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count > 0) return;
        Transform spawnPointsTrans = transform;
        foreach (Transform point in spawnPointsTrans)
        {
            this.spawnPoints.Add(point);
        }
        Debug.Log(transform.name + ": LoadSpawnPoints", transform.gameObject);
    }

    //======================================Other func=============================================
    public virtual Transform GetRandSpawnPoint()
    {
        int randIndex = Random.Range(0, this.spawnPoints.Count);
        return this.spawnPoints[randIndex];
    }
}
