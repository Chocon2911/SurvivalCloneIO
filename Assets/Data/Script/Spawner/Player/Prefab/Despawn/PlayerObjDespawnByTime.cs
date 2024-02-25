using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDespawnByTime : DespawnByTime
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjManager();
    }

    //===================================Load Component============================================
    protected virtual void LoadPlayerObjManager()
    {
        if (this.playerObjManager != null) return;
        this.playerObjManager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": LoadPlayerObjManager", transform.gameObject);
    }

    protected override IEnumerator DespawnObj()
    {
        yield return new WaitForSeconds(1);
        PlayerSpawner.Instance.DespawnObj(transform.parent);
        Debug.Log(transform.name + ": DespawnObj", transform.gameObject);
    }
}
