using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : HuyMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected float xInput;
    public float XInput => xInput;

    [SerializeField] protected float yInput;
    public float YInput => yInput;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only one instance exist at a time");
        else instance = this;
    }

    protected virtual void Update()
    {
        this.GetMoveInput();
    }

    protected virtual void GetMoveInput()
    {
        this.xInput = Input.GetAxisRaw("Horizontal");
        this.yInput = Input.GetAxisRaw("Vertical");
    }
}
