using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sender", menuName = "ScriptableObject/Damage/Sender")]
public class DamageSenderSO : ScriptableObject
{
    [SerializeField] protected List<string> canDamageTags; public List<string> CanDamageTags => canDamageTags;
    [SerializeField] protected float damage = 1f; public float Damage => damage;
}
