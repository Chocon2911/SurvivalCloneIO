using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatReceiver", menuName = "ScriptableObject/Stat/Sender")]
public class StatSenderSO : ScriptableObject
{
    [Header("Sender")]
    [SerializeField] protected List<string> canSendTags = new List<string>();
    public List<string> CanSendTags => canSendTags;

    [Header("Stat")]
    [SerializeField] protected float additionalDamage;
    public float AdditionalDamage => additionalDamage;

    [SerializeField] protected float additionalMoveSpeed;
    public float AdditionalMoveSpeed => additionalMoveSpeed;
}
