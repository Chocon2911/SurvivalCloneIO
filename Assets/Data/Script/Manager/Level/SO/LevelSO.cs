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
    [SerializeField] protected int enemySpawnAmount;
    public int EnemySpawnAmount => enemySpawnAmount;
}
