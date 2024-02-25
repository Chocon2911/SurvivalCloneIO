using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnObj : PlayerManagerChild
{
    protected virtual void Start()
    {
        this.SpawnPlayer();
    }

    //=====================================Spawn===================================================
    protected virtual void SpawnPlayer()
    {
        Vector3 spawnPos = this.playerManager.PlayerSpawnPoint.SpawnPoints[0].position;
        Quaternion spawnRot = this.playerManager.PlayerSpawnPoint.SpawnPoints[0].rotation;
        string prefabName = PlayerSpawner.Instance.PlayerOne;

        Transform newPrefab = PlayerSpawner.Instance.Spawn(prefabName, spawnPos, spawnRot);
        if (newPrefab == null )
        {
            Debug.LogError(transform.name + ": NewPlayer is null", transform.gameObject);
            return;
        }
        newPrefab.gameObject.SetActive(true);
        Debug.Log(transform.name + ": SpawnPlayer", transform.gameObject);
    }
}
