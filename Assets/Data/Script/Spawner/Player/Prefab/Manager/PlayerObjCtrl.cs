using UnityEngine;

[RequireComponent(typeof(PlayerObjManager))]
public class PlayerObjCtrl : HuyMonoBehaviour
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManager => playerObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjManager();
    }

    protected virtual void OnEnable()
    {
        this.UpdateHealth();
        this.UpdateStatSender();
    }

    protected virtual void Update()
    {
        this.UpdateHealth();
        this.UpdateStatSender();
        this.UpdateLevel();
    }

    //======================================Load Component=========================================
    protected virtual void LoadPlayerObjManager()
    {
        if (this.playerObjManager != null) return;
        this.playerObjManager = transform.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": LoadPlayerObjManager", transform.gameObject);
    }

    //==========================================Update=============================================
    protected virtual void UpdateHealth()
    {
        this.playerObjManager.PlayerObjStat.AddHealth(-this.playerObjManager.DamageReceiver.DamageTaken);
        this.playerObjManager.DamageReceiver.SetDamageTaken(0);
    }

    protected virtual void UpdateStatSender()
    {
        this.playerObjManager.StatSender.SetDamage(this.playerObjManager.PlayerObjStat.Damage);
        this.playerObjManager.StatSender.SetMoveSpeed(this.playerObjManager.PlayerObjStat.MoveSpeed);
    }

    protected virtual void UpdateLevel()
    {
        if (this.playerObjManager.PlayerObjStat.CurrentLevel >= this.playerObjManager.ExpReceiver.CurrLevel) return;
        this.playerObjManager.PlayerObjStat.AddCurrLevel(1);
        this.playerObjManager.PlayerObjStat.AddDamage(1);
        this.playerObjManager.PlayerObjStat.AddAttackCooldownMultiplier(0.5f);
    }
}
