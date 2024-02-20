using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FollowTargetSO", menuName = "ScriptableObject/Follower/Target")]
public class FollowTargetSO : ScriptableObject
{
    [SerializeField] protected float speed;
    public float Speed => speed;
}
