using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerObjLevel", menuName = "ScriptableObject/Player/Level")]
public class PlayerObjLevelSO : ScriptableObject
{
    [Header("Level")]
    [SerializeField] protected List<float> levelUpExps;
    public List<float> LevelUpExps => levelUpExps;
}
