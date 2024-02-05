using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovement",menuName = "ScriptableObject/PlayerObjMovement")]
public class PlayerObjMovementSO : ScriptableObject
{
    public float moveSpeed = 5f;
    public bool canMove = true;
    public bool isMoving = false;
}
