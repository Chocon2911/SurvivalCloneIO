using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByTime : Despawner
{
    [SerializeField] protected float despawnTimer = 0f;
    [SerializeField] protected float despawnTimeLimit = 5f;

    protected virtual void OnEnable()
    {
        this.despawnTimer = 0f;
    }

    protected override bool CanDespawn()
    {
        if (this.despawnTimer < this.despawnTimeLimit) this.despawnTimer += Time.deltaTime;
        return this.despawnTimer >= this.despawnTimeLimit;
    }
}
