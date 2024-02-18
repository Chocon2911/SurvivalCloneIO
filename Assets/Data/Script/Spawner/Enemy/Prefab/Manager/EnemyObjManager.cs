using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyObjManager : HuyMonoBehaviour
{
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected EnemyObjShoot enemyObjShoot;
    public EnemyObjShoot EnemyObjShoot => enemyObjShoot;

    [SerializeField] protected EnemyObjDespawnByHealth despawnByHealth;
    public EnemyObjDespawnByHealth DespawnByHealth => despawnByHealth;

    [SerializeField] protected EnemyObjFollowPlayer followPlayer;
    public EnemyObjFollowPlayer FollowPlayer => followPlayer;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected BoxCollider2D bodyCollider;
    public BoxCollider2D BodyCollider => bodyCollider;

    [SerializeField] protected EnemyObjSO enemyObjSO;
    public EnemyObjSO EnemyObjSO => enemyObjSO;

    [SerializeField] protected Transform closestActivePlayer;
    public Transform ClosestActivePlayer => closestActivePlayer;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
        this.LoadEnemyObjShoot();
        this.LoadDespawnByHealth();
        this.LoadFollowPlayer();
        this.LoadRigidbody();
        this.LoadBodyCollider();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.DefaultRigidbody();
        this.DefaultBodyCollider();
    }

    protected virtual void Update()
    {
        this.GetClosestPlayer();
    }

    //======================================Load Component=========================================
    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCollider != null) return;
        this.bodyCollider = transform.GetComponent<BoxCollider2D>();
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.Find("DamageReceiver").GetComponent<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", transform.gameObject);
    }

    protected virtual void LoadDespawnByHealth()
    {
        if (this.despawnByHealth != null) return;
        this.despawnByHealth = transform.Find("Despawn").GetComponent<EnemyObjDespawnByHealth>();
        Debug.Log(transform.name + ": LoadDespawnByHealth", transform.gameObject);
    }

    protected virtual void LoadEnemyObjShoot()
    {
        if (this.enemyObjShoot != null) return;
        this.enemyObjShoot = transform.Find("Shoot").GetComponent<EnemyObjShoot>();
        Debug.Log(transform.name + ": LoadEnemyObjShoot", transform.gameObject);
    }

    protected virtual void LoadFollowPlayer()
    {
        if (this.followPlayer != null) return;
        this.followPlayer = transform.Find("Movement").GetComponent<EnemyObjFollowPlayer>();
        Debug.Log(transform.name + ": LoadFollowPlayer", transform.gameObject);
    }

    //========================================Reset Value==========================================
    protected virtual void DefaultRigidbody()
    {
        if (this.rb == null) Debug.LogWarning("Rigidbody is null", transform.gameObject);
        this.rb.isKinematic = false;
        this.rb.gravityScale = 0;
        this.rb.drag = 0;
        this.rb.angularDrag = 0;
        this.rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        this.rb.freezeRotation = true;
    }

    protected virtual void DefaultBodyCollider()
    {
        if (this.bodyCollider == null) Debug.LogWarning("BodyCollider is null", transform.gameObject);
        this.bodyCollider.isTrigger = false;
    }

    //=======================================Getter================================================
    protected virtual void GetClosestPlayer()
    {
        float closestDistance = 100000000000;
        foreach (Transform obj in GameManager.Instance.ActivePlayers)
        {
            if (!obj.gameObject.activeSelf) return;
            Vector2 playerPos = obj.position;
            Vector2 transPos = transform.parent.position;
            float distance = Mathf.Sqrt(Mathf.Pow(transPos.x - playerPos.x, 2) + Mathf.Pow(transPos.y - playerPos.y, 2));

            if (distance >= closestDistance) return;
            closestDistance = distance;
            this.closestActivePlayer = obj;
        }
    }
}
