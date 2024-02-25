using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundSO", menuName = "ScriptableObject/Background")]
public class BackgroundSO : ScriptableObject
{
    [SerializeField] protected float speed;
    public float Speed => speed;
}
