using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Receiver", menuName = "ScriptableObject/Damage/Receiver")]
public class DamageReceiverSO : ScriptableObject
{
    [SerializeField] protected float maxHealth = 3f; public float MaxHealth => maxHealth;
}
