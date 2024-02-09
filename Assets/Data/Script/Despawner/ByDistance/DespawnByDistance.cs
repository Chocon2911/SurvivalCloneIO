using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByDistance : Despawner
{
    [SerializeField] protected float currDistance;
    [SerializeField] protected float maxDistance = 40f;

    protected override void Update()
    {
        base.Update();
    }

    protected override bool CanDespawn()
    {
        Vector2 cameraPos = GameManager.Instance.MainCamera.transform.position;
        Vector2 objPos = transform.parent.position;
        
        this.currDistance = Mathf.Sqrt(Mathf.Pow(objPos.x - cameraPos.x, 2) + Mathf.Pow(objPos.y - cameraPos.y, 2));
        return this.currDistance >= this.maxDistance;
    }
}
