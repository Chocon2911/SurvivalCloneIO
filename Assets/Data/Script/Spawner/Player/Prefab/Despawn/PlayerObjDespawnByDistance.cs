using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDespawnByDistance : DespawnByDistance
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    protected override IEnumerator DespawnObj()
    {
        yield return new WaitForSeconds(1);
        PlayerSpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }
}
