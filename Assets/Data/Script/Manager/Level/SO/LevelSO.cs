using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "ScriptableObject/Level")]
public class LevelSO : ScriptableObject
{
    [Header("LevelByTime")]
    [SerializeField] protected List<float> levelTimes = new List<float>();
    public List<float> LevelTimes => levelTimes;

    [Header("Enemy")]
    [SerializeField] protected List<int> enemySpawnAmountByLevel;
    public List<int> EnemySpawnAmountByLevel => enemySpawnAmountByLevel;
}
