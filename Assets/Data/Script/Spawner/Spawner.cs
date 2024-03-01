using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : HuyMonoBehaviour
{
    [SerializeField] protected Transform holderTrans;
    [SerializeField] protected List<Transform> holders;
    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolderTrans();
        this.LoadHolders();
        this.LoadPrefabs();
    }

    //==================================Load Component=============================================
    protected virtual void LoadHolderTrans()
    {
        if (this.holderTrans != null) return;
        this.holderTrans = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolderTrans", transform.gameObject);
    }

    protected virtual void LoadHolders()
    {
        if (this.holders.Count > 0) return;
        Transform holderTrans = transform.Find("Holder");
        if (holderTrans == null) Debug.LogWarning("There are no Transform name Holder", transform.gameObject);
        foreach (Transform obj in holderTrans)
        {
            this.holders.Add(obj);
        }
        Debug.Log(transform.name + ": LoadHolders", transform.gameObject);
    }

    protected virtual void LoadPrefabs()
    { 
        if (this.prefabs.Count > 0) return;
        Transform prefabTrans = transform.Find("Prefabs");
        if (prefabTrans == null) Debug.LogWarning("There are no Transform name Prefabs", transform.gameObject);
        foreach (Transform obj in prefabTrans)
        {
            this.prefabs.Add(obj);
        }
        Debug.Log(transform.name + ": LoadPrefabs", transform.gameObject);
        this.HidePrefab();
    }

    //=====================================Public==================================================
    public virtual Transform Spawn(string name, Vector2 pos, Quaternion rot)
    {
        Transform prefab = this.GetPrefabByName(name);
        Transform newPrefab = this.CloneObj(prefab);
        newPrefab.SetPositionAndRotation(pos, rot);
        newPrefab.parent = this.holderTrans;
        return newPrefab;
    }

    public virtual void DespawnObj(Transform prefab)
    {
        prefab.gameObject.SetActive(false);
        this.holders.Add(prefab);
    }

    //==================================Other Func=================================================
    protected virtual void HidePrefab()
    {
        foreach (Transform obj in this.prefabs) obj.gameObject.SetActive(false);
        Debug.Log(transform.name + ": HidePrefab", transform.gameObject);
    }

    protected virtual Transform GetPrefabByName(string name)
    {
        foreach (Transform obj in this.prefabs)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        Debug.LogWarning("No prefab name: " + name, transform.gameObject);
        return null;
    }

    protected virtual Transform CloneObj(Transform prefab)
    {
        foreach(Transform obj in this.holders)
        {
            if (obj.name == prefab.name + "(Clone)")
            {
                this.holders.Remove(obj);
                return obj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        return newPrefab;
    }
}
