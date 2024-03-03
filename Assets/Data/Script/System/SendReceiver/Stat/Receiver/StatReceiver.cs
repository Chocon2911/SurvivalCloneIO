using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatReceiver : HuyMonoBehaviour
{
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
