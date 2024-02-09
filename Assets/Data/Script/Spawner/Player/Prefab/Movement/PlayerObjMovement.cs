using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerObjMovement : HuyMonoBehaviour
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    [Header("Move")]
    [SerializeField] protected float moveSpeed = 0f;
    [SerializeField] protected bool canMove = false;
    [SerializeField] protected bool isMoving = false;

    [Header("Dash")]
    [SerializeField] protected float dashSpeed = 0f;

    [SerializeField] protected float dashCooldown = 0f;
    [SerializeField] private float dashCooldownTimer = 0f;
    [SerializeField] protected float dashInterval = 0f;
    [SerializeField] private float dashIntervalTimer = 0f;

    [SerializeField] protected bool canDash = false;
    [SerializeField] protected bool isDashing = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjManager();
    }

    protected virtual void OnEnable()
    {
        this.canMove = true;
        this.GetBaseStat();
    }

    protected virtual void Update()
    {
        this.IsDashing();
        this.CanDash();
    }

    protected virtual void FixedUpdate()
    {
        this.Dash();
        if (this.IsDashing()) return;
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
        if (!this.canMove) return;

        float xInput = InputManager.Instance.XInput;
        float yInput = InputManager.Instance.YInput;
        Vector2 input = new Vector2(xInput, yInput);

        this.isMoving = (xInput != 0 || yInput != 0);

        Vector2 velocity = input.normalized * this.moveSpeed;
        this.playerObjManager.Rb.velocity = velocity;
    }

    //=======================================Dash==================================================
    protected virtual bool CanDash()
    {
        if (this.IsDashing()) return false;
        if (this.dashCooldownTimer < dashCooldown) this.dashCooldownTimer += Time.deltaTime;

        this.canDash = this.dashCooldownTimer >= this.dashCooldown;
        return this.canDash;
    }

    protected virtual bool IsDashing()
    {
        if (this.dashIntervalTimer < this.dashInterval) this.dashIntervalTimer += Time.deltaTime;

        this.isDashing = this.dashIntervalTimer < this.dashInterval;
        return this.isDashing;
    }
    
    protected virtual void Dash()
    {
        if (!this.CanDash()) return;

        float dashInput = InputManager.Instance.DashInput;
        if (dashInput == 0) return;

        float xInput = InputManager.Instance.XInput;
        float yInput = InputManager.Instance.YInput;
        Vector2 input = new Vector2 (xInput, yInput);

        Vector2 velocity = input.normalized * this.dashSpeed;

        this.playerObjManager.Rb.velocity = velocity;
        this.dashIntervalTimer = 0f;
        this.dashCooldownTimer = 0f;
    }

    //======================================On Enable==============================================
    protected virtual void GetBaseStat()
    {
        this.moveSpeed = this.playerObjManager.PlayerObjSO.MoveSpeed;
        this.canMove = true;
        this.isMoving = false;

        this.dashSpeed = this.playerObjManager.PlayerObjSO.DashSpeed;
        this.dashCooldown = this.playerObjManager.PlayerObjSO.DashCooldown;
        this.dashInterval = this.playerObjManager.PlayerObjSO.DashInterval;
    }
}