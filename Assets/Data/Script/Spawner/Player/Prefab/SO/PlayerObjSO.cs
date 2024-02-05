using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObject/Player/Obj")]
public class PlayerObjSO : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f; public float MoveSpeed => moveSpeed;
    [SerializeField] private float dashSpeed = 20f; public float DashSpeed => dashSpeed;
    [SerializeField] private float dashCooldown = 1f; public float DashCooldown => dashCooldown;
    [SerializeField] private float dashInterval = 0.5f; public float DashInterval => dashInterval;

    [Header("Stat")]
    [SerializeField] private float hp = 3f; public float Hp => hp;
    [SerializeField] private float damge = 1f; public float Damge => damge;
    [SerializeField] private float attackCooldown = 1f; public float AttackCooldown => attackCooldown;
}
