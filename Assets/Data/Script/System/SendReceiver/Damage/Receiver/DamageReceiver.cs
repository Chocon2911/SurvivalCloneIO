using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageReceiver : HuyMonoBehaviour
{
    [Header("Stat")]
    [SerializeField] public float damageTaken; public float DamageTaken => damageTaken;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //========================================Damage===============================================
    public virtual void AddDamageTaken(float damage)
    {
        this.damageTaken += damage;
        Debug.Log(transform.name + ": Get " + damage + "damage", transform.gameObject);
    }

    //========================================public===============================================
    public virtual void SetDamageTaken(float damageTaken)
    {
        this.damageTaken = damageTaken;
    }

    //======================================Other Func=============================================
    protected virtual void DefaultStat()
    {
        this.damageTaken = 0;
    }
}
