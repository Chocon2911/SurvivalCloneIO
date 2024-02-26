using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatReceiver : HuyMonoBehaviour
{
    [Header("Stat")]
    [SerializeField] protected List<string> canSendTags = new List<string>();
    public List<string> CanSendTags => canSendTags;

    [Header("Additional")]
    [SerializeField] protected float additionalDamage;
    public float AdditionalDamage => additionalDamage;

    [SerializeField] protected float additionalMoveSpeed;
    public float AdditionalMoveSpeed => additionalMoveSpeed;

    //=============================================public==========================================
    public virtual void ReceiveStat(float additionalDamage, float additionalMoveSpeed)
    {
        this.additionalDamage = additionalDamage;
        this.additionalMoveSpeed = additionalMoveSpeed;
    }
}
