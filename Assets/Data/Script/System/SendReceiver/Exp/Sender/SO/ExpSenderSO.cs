using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUpSenderSO", menuName = "ScriptableObject/Exp/Sender")]
public class ExpSenderSO : ScriptableObject
{
    [SerializeField] protected List<string> canPickUpTags = new List<string>();
    public List<string> CanPickUpTags => canPickUpTags;

    [SerializeField] protected int expAmount = 1;
    public int ExpAmount => expAmount;
}
