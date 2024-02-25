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
}