using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUpReceiverSO", menuName = "ScriptableObject/Exp/Receiver")]
public class ExpReceiverSO : ScriptableObject
{
    [SerializeField] protected int currLevel;
    public int CurrLevel => currLevel;

    [SerializeField] protected List<int> exp2LevelUps;
    public List<int> Exp2LevelUps => exp2LevelUps;
}
