using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy/Manager")]
public class EnemySO : ScriptableObject
{
    [SerializeField] protected float cooldown = 10f; 
    public float Cooldown => cooldown;

    [SerializeField] protected int maxEnemy;
    public int MaxEnemy => maxEnemy;

    [SerializeField] protected int spawnAmount;
    public int SpawnAmount => spawnAmount;
}
