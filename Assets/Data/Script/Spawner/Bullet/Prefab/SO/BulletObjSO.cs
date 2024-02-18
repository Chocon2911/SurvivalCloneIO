using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletObj", menuName = "ScriptableObject/Bullet/Obj")]
public class BulletObjSO : ScriptableObject
{
    [SerializeField] protected List<string> canDamageTags; public List<string> CanDamgeTags => canDamageTags;
    [SerializeField] protected float moveSpeed = 7f; public float MoveSpeed => moveSpeed;
    [SerializeField] protected float damage = 1f; public float Damage => damage;
    [SerializeField] protected float existTime = 10f; public float ExistTime => existTime;
    [SerializeField] protected float maxDistance = 50f; public float MaxDistance => maxDistance;
}
