using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjLevel : HuyMonoBehaviour
{
    [SerializeField] protected PlayerObjManager playerObjManager;
    public PlayerObjManager PlayerObjManger => playerObjManager;

    [SerializeField] protected PlayerObjLevelSO playerObjLevelSO;
    public PlayerObjLevelSO PlayerObjLevelSO => playerObjLevelSO;

    [Header("Level")]
    [SerializeField] protected float currLevel = 0;
    public float CurrentLevel => currLevel;

    [SerializeField] protected float currExp = 0;
    public float CurrExp => currExp;

    [SerializeField] protected List<float> levelUpExps;
    public List<float> LevelUpExps => levelUpExps;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerObjManager();
    }

    //=====================================Load Component==========================================
    protected virtual void LoadPlayerObjManager()
    {
        if (this.playerObjManager != null) return;
        this.playerObjManager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": LoadPlayerObjManager", transform.gameObject);
    }

    //=======================================Other Func============================================
    protected virtual void DefaultStat()
    {
        if (this.playerObjLevelSO == null) Debug.LogError(transform.name + ": No playerObjLevelSO", transform.gameObject);
        this.currLevel = 0;

        if (this.playerObjLevelSO.LevelUpExps.Count <= 0)
        {
            Debug.LogError(transform.name + ": LevelUpExps must be greater than 0");
            return;
        }
        this.levelUpExps = this.playerObjLevelSO.LevelUpExps;
    }
}
