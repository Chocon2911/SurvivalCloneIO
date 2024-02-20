using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : HuyMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [Header("Move")]
    [SerializeField] protected float xInput;
    public float XInput => xInput;

    [SerializeField] protected float yInput;
    public float YInput => yInput;

    [SerializeField] protected float dashInput;
    public float DashInput => dashInput;

    [Header("Attack")]
    [SerializeField] protected float shootInput;
    public float ShootInput => shootInput;

    [Header("Other")]
    [SerializeField] protected Vector2 worldMousePos;
    public Vector2 WorldMousePos => worldMousePos;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one instance exist at a time");
        else instance = this;
    }

    protected virtual void Update()
    {
        this.GetMoveInput();
        this.GetAttackInput();
        this.GetMouseInput();
    }

    protected virtual void GetMoveInput()
    {
        this.xInput = Input.GetAxisRaw("Horizontal");
        this.yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift)) this.dashInput = 1;
        else this.dashInput = 0;
    }

    protected virtual void GetAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)) this.shootInput = 1;
        else this.shootInput = 0;
    }

    protected virtual void GetMouseInput()
    {
        this.worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
