using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObject/Level")]
public class LevelSO : ScriptableObject
{
    [Header("Time")]
    [SerializeField] protected List<float> timeLevel; public List<float> TimeLevel => timeLevel;
}
