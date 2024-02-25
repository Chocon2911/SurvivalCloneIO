using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpObjSO", menuName = "ScriptableObject/Exp/Obj")]
public class ExpObjSO : ScriptableObject
{
    [SerializeField] protected float speed;
    public float Speed => speed;

    [SerializeField] protected float bodyCollideRadius;
    public float BodyCollideRadius => bodyCollideRadius;

    [SerializeField] protected float detectZoneRadius;
    public float DetectZoneRadius => detectZoneRadius;
}
