using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FollowCamera", menuName = "ScriptableObject/Follower/Camera")]
public class FollowCameraSO : ScriptableObject
{
    [SerializeField] protected float speed; public float Speed => speed;
}
