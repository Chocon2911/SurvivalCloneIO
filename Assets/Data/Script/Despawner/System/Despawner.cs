using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : HuyMonoBehaviour
{
    protected virtual void Update()
    {
        this.CanDespawn();
        this.Despawn();
    }

    private void Despawn()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObj();
    }

    protected virtual void DespawnObj()
    {
        Destroy(transform.parent.gameObject);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }

    protected abstract bool CanDespawn();
}
