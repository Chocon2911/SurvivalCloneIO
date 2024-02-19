using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : HuyMonoBehaviour
{
    [SerializeField] protected FollowPlayerSO followPlayerSO;

    [Header("Stat")]
    [SerializeField] protected float speed;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected virtual void FixedUpdate()
    {
        this.FollowPlayerObj();
    }

    //==================================Follower===================================================
    protected virtual void FollowPlayerObj()
    {
        Vector3 targetPos = this.GetMidOfPlayers();
        Vector3 currPos = transform.position;
        Vector3 zPos = new Vector3(0, 0, targetPos.z + 10);

        Vector3 newPos = Vector3.Lerp(currPos, targetPos - zPos, speed);
        transform.position = newPos;
    }

    protected virtual Vector3 GetMidOfPlayers()
    {
        List<Transform> activePlayers = GameManager.Instance.ActivePlayers;
        Vector3 sumOfPos = Vector2.zero;

        if (activePlayers.Count == 0) return GameManager.Instance.MainCamera.transform.position;
        foreach (Transform obj in activePlayers)
        {
            Vector3 objPos = obj.position;
            sumOfPos = sumOfPos + objPos;
        }

        return sumOfPos / activePlayers.Count;
    }

    //=================================Other Func==================================================
    protected virtual void DefaultStat()
    {
        if (this.followPlayerSO == null) Debug.LogError(transform.name + ": no followCameraSO", transform.gameObject);
        this.speed = this.followPlayerSO.Speed;
    }
}
