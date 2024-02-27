using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectSenderSO", menuName = "ScriptableObject/Effect/Sender")]
public class EffectSenderSO : ScriptableObject
{
    [Header("Detect")]
    [SerializeField] protected List<string> canSendTags = new List<string>();
    public List<string> CanSendTags => canSendTags;

    [Header("Additional Damage")]
    [SerializeField] protected float additionalDamage;
    public float AdditionalDamage => additionalDamage;

    [SerializeField] protected float additionalDamageTime;
    public float AdditionalDamageTime => additionalDamageTime;

    [Header("Multiplier Damage")]
    [SerializeField] protected float damageMultiplier;
    public float DamageMultiplier => damageMultiplier;

    [SerializeField] protected float damageMultiplierTime;
    public float DamageMultiplierTime => damageMultiplierTime;

    [Header("Multiplier Attack Speed")]
    [SerializeField] protected float attackSpeedMultiplier;
    public float AttackSpeedMultiplier => attackSpeedMultiplier;

    [SerializeField] protected float attackSpeedMultiplierTime;
    public float AttackSpeedMultiplierTime => attackSpeedMultiplierTime;
}