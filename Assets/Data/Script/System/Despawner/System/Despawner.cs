using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : HuyMonoBehaviour
{
    [SerializeField] protected bool canDespawn;

    protected virtual void OnEnable()
    {
        this.canDespawn = false;
    }

    protected virtual void LateUpdate() 
    {
        this.CheckCanDespawn();
        this.Despawn();
    }

    protected virtual void Despawn()
    {
        if (!this.canDespawn) return;
        this.DespawnObj();
    }

    protected virtual IEnumerator DespawnObj()
    {
        yield return new WaitForSeconds(1);
        Destroy(transform.parent.gameObject);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }

    //====================================Checker==================================================
    protected abstract void CheckCanDespawn();
}
