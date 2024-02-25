using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy/Manager")]
public class EnemySO : ScriptableObject
{
    [Header("Spawn")]
    [SerializeField] protected float cooldown = 10f;
    public float Cooldown => cooldown;

    [SerializeField] protected int maxEnemy;
    public int MaxEnemy => maxEnemy;

    [Header("Camera")]
    [SerializeField] protected float followCameraSpeed;
    public float FollowCameraSpeed => followCameraSpeed;
}
