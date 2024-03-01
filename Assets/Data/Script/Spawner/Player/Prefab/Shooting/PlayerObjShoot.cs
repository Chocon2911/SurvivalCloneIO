using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjShoot : HuyMonoBehaviour
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    [Header("Stat")]
    [SerializeField] protected float radius = 1f;


    [SerializeField] protected float shootCoolDownTimer;
    [SerializeField] protected float shootChargeTimer;

    [SerializeField] protected bool canShoot = false;
    public bool CanShoot => canShoot;
    [SerializeField] protected bool isShooting = false;
    public bool IsShooting => isShooting;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
    }

    protected virtual void Update()
    {
        this.CheckCanShoot();
        this.CheckIsShooting();
        this.Shoot();
    }

    //========================================Load Component=======================================
    protected virtual void LoadPlayerManager()
    {
        if (this.playerObjManager != null) return;
        this.playerObjManager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }

    //==========================================Check=============================================
    protected virtual void CheckCanShoot()
    {
        float shootCoolDown = this.playerObjManager.PlayerObjStat.AttackCooldown;
        if (this.shootCoolDownTimer < shootCoolDown && !this.isShooting) this.shootCoolDownTimer += Time.deltaTime;
        this.canShoot = this.shootCoolDownTimer >= shootCoolDown;
    }

    protected virtual void CheckIsShooting()
    {
        float shootCharge = this.playerObjManager.PlayerObjStat.AttackCharge;
        if (this.shootChargeTimer < shootCharge) this.shootChargeTimer += Time.deltaTime;
        this.isShooting = this.shootChargeTimer < shootCharge;
    }

    //==========================================Shoot==============================================
    protected virtual void Shoot()
    {
        float shootInput = InputManager.Instance.ShootInput;
        if (this.isShooting || !this.canShoot || shootInput == 0) return;
        StartCoroutine(this.Shooting());
    }

    protected virtual IEnumerator Shooting()
    {
        this.shootCoolDownTimer = 0f;
        this.shootChargeTimer = 0f;
        float shootCharge = this.playerObjManager.PlayerObjStat.AttackCharge;
        yield return new WaitForSeconds(shootCharge);

        Vector2 spawnPos = this.SpawnPos();
        Quaternion spawnRot = this.SpawnRot();

        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.BulletOne, spawnPos, spawnRot);
        if (newBullet == null)
        {
            Debug.LogError(transform.name + ": newBullet is null", transform.gameObject);
            yield break;
        }
        this.playerObjManager.StatSender.SendStat(newBullet);
        newBullet.gameObject.SetActive(true);
    }

    protected virtual Vector2 SpawnPos()
    {
        Vector2 mousePos = InputManager.Instance.WorldMousePos;
        Vector2 objPos = transform.parent.position;
        Vector2 dir = GetDir(objPos, mousePos).normalized;
        return objPos + dir;
    }

    protected virtual Quaternion SpawnRot()
    {
        Vector2 mousePos = InputManager.Instance.WorldMousePos;
        Vector2 objPos = transform.parent.position;
        Vector2 dir = GetDir(objPos, mousePos);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        return rotation;
    }

    //=========================================Other Func==========================================
    protected virtual Vector2 GetDir(Vector2 startPoint, Vector2 endPoint)
    {
        Vector2 dir = endPoint - startPoint;
        return dir;
    }
}
