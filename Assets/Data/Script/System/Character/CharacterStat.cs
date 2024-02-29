using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStat : HuyMonoBehaviour
{
    [Header("Stat")]
    [SerializeField] protected float maxHealth;
    public float MaxHealth => maxHealth;

    [SerializeField] protected float health;
    public float Health => health;

    [Header("Attack")]
    [SerializeField] protected float damage;
    public float Damage => damage;

    [SerializeField] protected float attackCooldown;
    public float AttackCooldown => attackCooldown;

    [SerializeField] protected float attackCharge;
    public float AttackCharge => attackCharge;

    [Header("Move")]
    [SerializeField] protected float moveSpeed;
    public float MoveSpeed => moveSpeed;

    [SerializeField] protected float dashSpeed;
    public float DashSpeed => dashSpeed;

    [SerializeField] protected float dashInterval;
    public float DashInterval => dashInterval;

    [SerializeField] protected float dashCooldown;
    public float DashCooldown => dashCooldown;

    //===========================================public=============================================
    //============================================Stat==============================================
    //Health
    public virtual void AddHealth(float health)
    {
        this.health += health;
    }

    public virtual void AddHealthMultiplier(float healthMultiplier)
    {
        this.health *= healthMultiplier;
        Debug.Log(transform.name + ": AddHealthMultiplier", transform.gameObject);
    }

    //MaxHealth
    public virtual void AddMaxHealth(float health)
    {
        this.maxHealth += health;
        Debug.Log(transform.name + ": AddMaxHealth", transform.gameObject);
    }
    public virtual void AddMaxHealth(float health, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddMaxHealthTime(health, time));
        Debug.Log(transform.name + ": AddMaxHealth", transform.gameObject);
    }

    public virtual void AddMaxHealthMultiplier(float health)
    {
        this.maxHealth *= health;
        Debug.Log(transform.name + ": AddMaxHealthMultiplier", transform.gameObject);
    }
    public virtual void AddMaxHealthMultiplier(float health, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddMaxHealthMultiplierTime(health, time));
        Debug.Log(transform.name + ": AddMaxHealthMultiplier", transform.gameObject);
    }

    //============================================Attack============================================
    //Damage
    public virtual void AddDamage(float damage)
    {
        this.damage += damage;
        Debug.Log(transform.name + ": AddDamage", transform.gameObject);
    }
    public virtual void AddDamage(float damage, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDamageTime(damage, time));
        Debug.Log(transform.name + ": AddDamage", transform.gameObject);
    }

    public virtual void AddDamageMultiplier(float damageMultiplier)
    {
        this.damage *= damageMultiplier;
        Debug.Log(transform.name + ": AddDamageMultiplier", transform.gameObject);
    }
    public virtual void AddDamageMultiplier(float damageMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDamageMultiplierTime(damageMultiplier, time));
        Debug.Log(transform.name + ": AddDamageMultiplier", transform.gameObject);
    }

    //AttackCooldown
    public virtual void AddAttackCooldown(float attackCooldown)
    {
        this.attackCooldown += attackCooldown;
        Debug.Log(transform.name + ": AddAttackSpeed", transform.gameObject);
    }
    public virtual void AddAttackCooldown(float attackCooldown, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddAttackCooldownTime(attackCooldown, time));
        Debug.Log(transform.name + ": AddAttackSpeed", transform.gameObject);
    }

    public virtual void AddAttackCooldownMultiplier(float attackCooldownMultiplier)
    {
        this.attackCooldown *= attackCooldownMultiplier;
        Debug.Log(transform.name + ": AddAttackSpeedMultiplier", transform.gameObject);
    }
    public virtual void AddAttackCooldownMultiplier(float attackSpeedMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddAttackCooldownMultiplierTime(attackSpeedMultiplier, time));
        Debug.Log(transform.name + ": AddAttackSpeedMultiplier", transform.gameObject);
    }

    //AttackCharge
    public virtual void AddAttackCharge(float attackCharge)
    {
        this.attackCharge += attackCharge;
        Debug.Log(transform.name + ": AddAttackCharge", transform.gameObject);
    }
    public virtual void AddAttackCharge(float attackCharge, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddAttackChargeTime(attackCharge, time));
        Debug.Log(transform.name + ": AddAttackCharge", transform.gameObject);
    }

    public virtual void AddAttackChargeMultiplier(float attackChargeMultiplier)
    {
        this.attackCharge *= attackChargeMultiplier;
        Debug.Log(transform.name + ": AddAttackChargeMultiplier", transform.gameObject);
    }
    public virtual void AddAttackChargeMultiplier(float attackChargeMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(AddAttackChargeMultiplierTime(attackChargeMultiplier, time));
        Debug.Log(transform.name + ": AddAttackChargeMultiplier", transform.gameObject);
    }

    //=============================================Move=============================================
    //MoveSpeed
    public virtual void AddMoveSpeed(float speed)
    {
        this.moveSpeed += speed;
        Debug.Log(transform.name + ": AddMoveSpeed", transform.gameObject);
    }
    public virtual void AddMoveSpeed(float speed, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddAttackCooldownTime(speed, time));
        Debug.Log(transform.name + ": AddMoveSpeed", transform.gameObject);
    }

    public virtual void AddMoveSpeedMultiplier(float speedMultiplier)
    {
        this.moveSpeed *= speedMultiplier;
        Debug.Log(transform.name + ": AddMoveSpeedMultiplier", transform.gameObject);
    }
    public virtual void AddMoveSpeedMultiplier(float speedMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddAttackCooldownMultiplierTime(speedMultiplier, time));
        Debug.Log(transform.name + ": AddMoveSpeedMultiplier", transform.gameObject);
    }

    //DashSpeed
    public virtual void AddDashSpeed(float dashSpeed)
    {
        this.dashSpeed += dashSpeed;
        Debug.Log(transform.name + ": AddDashSpeed", transform.gameObject);
    }
    public virtual void AddDashSpeed(float dashSpeed, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDashSpeedTime(dashSpeed, time));
        Debug.Log(transform.name + ": AddDashSpeed", transform.gameObject);
    }

    public virtual void AddDashSpeedMultiplier(float dashSpeedMultiplier)
    {
        this.dashSpeed *= dashSpeedMultiplier;
        Debug.Log(transform.name + ": AddDashSpeedMultiplier", transform.gameObject);
    }
    public virtual void AddDashSpeedMultiplier(float dashSpeedMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDashSpeedMultiplierTime(dashSpeedMultiplier, time));
        Debug.Log(transform.name + ": AddDashSpeedMultiplier", transform.gameObject);
    }

    //DashInterval
    public virtual void AddDashInterval(float dashInterval)
    {
        this.dashInterval += dashInterval;
        Debug.Log(transform.name + ": AddDashInterval", transform.gameObject);
    }
    public virtual void AddDashInterval(float dashInterval, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDashSpeedMultiplierTime(dashInterval, time));
        Debug.Log(transform.name + ": AddDashInterval", transform.gameObject);
    }

    //DashCooldown
    public virtual void AddDashCooldown(float dashCooldown)
    {
        this.dashCooldown += dashCooldown;
        Debug.Log(transform.name + ": AddDashCooldown", transform.gameObject);
    }
    public virtual void AddDashCooldown(float dashCooldown, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDashCooldownTime(dashCooldown, time));
        Debug.Log(transform.name + ": AddDashCooldown", transform.gameObject);
    }

    public virtual void AddDashCooldownMultiplier(float dashCooldownMultiplier)
    {
        this.dashCooldown *= dashCooldownMultiplier;
        Debug.Log(transform.name + ": AddDashCooldownMultiplier", transform.gameObject);
    }
    public virtual void AddDashCooldownMultiplier(float dashCooldownMultiplier, float time)
    {
        if (time <= 0) Debug.LogError(transform.name + ": Wrong time value", transform.gameObject);
        StartCoroutine(this.AddDashCooldownMultiplierTime(dashCooldownMultiplier, time));
        Debug.Log(transform.name + ": AddDashCooldownMultiplier", transform.gameObject);
    }

    //========================================Stat Time=============================================
    //==========================================Stat================================================
    //MaxHealth
    protected virtual IEnumerator AddMaxHealthTime(float health, float time)
    {
        this.maxHealth += health;
        this.health += health;
        yield return new WaitForSeconds(time);
        this.maxHealth -= health;
        if (this.health - health <= 0) this.health = 1;
    }
    protected virtual IEnumerator AddMaxHealthMultiplierTime(float healthMultiplier, float time)
    {
        this.maxHealth *= healthMultiplier;
        this.health *= healthMultiplier;
        yield return new WaitForSeconds(time);
        this.maxHealth -= healthMultiplier;
        this.health /= healthMultiplier;
    }

    //===========================================Attack=============================================
    //Damage
    protected virtual IEnumerator AddDamageTime(float damage, float time)
    {
        this.damage += damage;
        yield return new WaitForSeconds(time);
        this.damage -= damage;
    }
    protected virtual IEnumerator AddDamageMultiplierTime(float damageMultiplier, float time)
    {
        this.damage *= damageMultiplier;
        yield return new WaitForSeconds(time);
        this.damage /= damageMultiplier;
    }

    //AttackSpeed
    protected virtual IEnumerator AddAttackCooldownTime(float attackCooldown, float time)
    {
        this.attackCooldown += attackCooldown;
        yield return new WaitForSeconds(time);
        this.attackCooldown -= attackCooldown;
    }
    protected virtual IEnumerator AddAttackCooldownMultiplierTime(float attackCooldownMultiplier, float time)
    {
        this.attackCooldown *= attackCooldownMultiplier;
        yield return new WaitForSeconds(time);
        this.attackCooldown /= attackCooldownMultiplier;
    }

    //AttackCharge
    protected virtual IEnumerator AddAttackChargeTime(float attackCharge, float time)
    {
        this.attackCharge += attackCharge;
        yield return new WaitForSeconds(time);
        this.attackCharge -= attackCharge;
    }

    protected virtual IEnumerator AddAttackChargeMultiplierTime(float attackChargeMultiplier, float time)
    {
        this.attackCharge *= attackChargeMultiplier;
        yield return new WaitForSeconds(time);
        this.attackCharge /= attackChargeMultiplier;
    }

    //=============================================Move=============================================
    //MoveSpeed
    protected virtual IEnumerator AddMoveSpeedTime(float moveSpeed, float time)
    {
        this.moveSpeed += moveSpeed;
        yield return new WaitForSeconds(time);
        this.moveSpeed -= moveSpeed;
    }
    protected virtual IEnumerator AddMoveSpedMultiplierTime(float moveSpeedMultiplier, float time)
    {
        this.moveSpeed *= moveSpeedMultiplier;
        yield return new WaitForSeconds(time);
        this.moveSpeed /= moveSpeedMultiplier;
    }

    //DashSpeed
    protected virtual IEnumerator AddDashSpeedTime(float dashSpeed, float time)
    {
        this.dashSpeed += dashSpeed;
        yield return new WaitForSeconds(time);
        this.dashSpeed -= dashSpeed;
    }
    protected virtual IEnumerator AddDashSpeedMultiplierTime(float dashSpeedMultiplier, float time)
    {
        this.dashSpeed *= dashSpeedMultiplier;
        yield return new WaitForSeconds(time);
        this.dashSpeed /= dashSpeedMultiplier;
    }

    //DashCooldown
    protected virtual IEnumerator AddDashCooldownTime(float dashCooldown, float time)
    {
        this.dashCooldown += dashCooldown;
        yield return new WaitForSeconds(time);
        this.dashCooldown -= dashCooldown;
    }
    protected virtual IEnumerator AddDashCooldownMultiplierTime(float dashCooldown, float time)
    {
        this.dashCooldown *= dashCooldown;
        yield return new WaitForSeconds(time);
        this.dashCooldown /= dashCooldown;
    }
}
