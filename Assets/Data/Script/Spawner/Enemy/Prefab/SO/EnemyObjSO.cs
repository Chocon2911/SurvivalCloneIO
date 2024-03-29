using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyObjSO", menuName = "ScriptableObject/Enemy/Obj")]
public class EnemyObjSO : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] protected float moveSpeed = 1f; public float MoveSpeed => moveSpeed;


    [Header("Attack")]
    [SerializeField] protected float damage = 1f; public float Damage => damage;
    [SerializeField] protected float shootCooldown = 0.5f; public float ShootCooldown => shootCooldown;
    [SerializeField] protected float shootCharge = 0f; public float ShootCharge => shootCharge;

    [Header("Health")]
    [SerializeField] protected float health = 3f; public float Health => health;

    [Header("Attack Range")]
    [SerializeField] protected float shootPosRadius; public float ShootPosRadius => shootPosRadius;
}
