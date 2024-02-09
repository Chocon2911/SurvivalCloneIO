using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletObj", menuName = "ScriptableObject/Bullet/BulletObjSO")]
public class BulletObjSO : ScriptableObject
{
    [SerializeField] protected float moveSpeed = 7f; public float MoveSpeed => moveSpeed;
    [SerializeField] protected float damage = 1f; public float Damage => damage;
    [SerializeField] protected float existTime = 10f; public float ExistTime => existTime;
    [SerializeField] protected float maxDistance = 50f; public float MaxDistance => maxDistance;
}
