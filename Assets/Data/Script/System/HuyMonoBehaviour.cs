using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HuyMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponent();
    }

    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void LoadComponent()
    {
        //For Override
    }

    protected virtual void ResetValue()
    {
        //For Override
    }
}
