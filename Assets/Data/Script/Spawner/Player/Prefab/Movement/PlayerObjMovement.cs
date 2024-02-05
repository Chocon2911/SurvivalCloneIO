using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerObjMovement : HuyMonoBehaviour
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    [SerializeField] protected PlayerObjMovementSO movementSO;
    public PlayerObjMovementSO MovementSO => movementSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjManager();
    }

    protected virtual void FixedUpdate()
    {
        this.Move();
    }

    //===================================Load Component============================================
    protected virtual void LoadPlayerObjManager()
    {
        if (this.playerObjManager != null) return;
        this.playerObjManager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": LoadPlayerObjManager", transform.gameObject);
    }

    //=======================================Move==================================================
    protected virtual void Move()
    {
        if (!this.movementSO.canMove) return;

        float xInput = InputManager.Instance.XInput;
        float yInput = InputManager.Instance.YInput;
        Vector2 input = new Vector2(xInput, yInput);

        this.movementSO.isMoving = (xInput != 0 || yInput != 0); 

        Vector2 velocity = input.normalized * this.movementSO.moveSpeed;
        this.playerObjManager.Rb.velocity = velocity;
    }
}
