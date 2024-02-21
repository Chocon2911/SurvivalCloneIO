using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSO", menuName = "ScriptableObject/Camera")]
public class CameraSO : ScriptableObject
{
    [SerializeField] protected float speed;
    public float Speed => speed;
}
