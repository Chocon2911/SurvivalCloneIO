using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FollowPlayer", menuName = "ScriptableObject/Follower/Player")]
public class FollowPlayerSO : ScriptableObject
{
    [SerializeField] protected float speed; public float Speed => speed;
}
