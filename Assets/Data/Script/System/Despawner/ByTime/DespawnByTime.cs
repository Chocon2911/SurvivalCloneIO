using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByTime : Despawner
{
    [SerializeField] protected float despawnTimer = 0f;
    [SerializeField] protected float despawnTimeLimit = 5f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.despawnTimer = 0f;
    }

    protected override void CheckCanDespawn()
    {
        if (this.despawnTimer < this.despawnTimeLimit) this.despawnTimer += Time.deltaTime;
        this.canDespawn = this.despawnTimer >= this.despawnTimeLimit;
    }
}
