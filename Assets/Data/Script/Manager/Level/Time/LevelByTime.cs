using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByTime : HuyMonoBehaviour
{
    [SerializeField] protected LevelManager levelManager;
    public LevelManager LevelManager => levelManager;

    [Header("Level")]
    [SerializeField] protected int currLevel;
    public int CurrentLevel => currLevel;

    [SerializeField] protected float currTime;
    public float CurrentTime => currTime;

    [SerializeField] protected List<float> levelTimes = new List<float>();
    public List<float> LevelTimes => levelTimes;

    [Header("Enemy")]
    [SerializeField] protected int enemySpawnAmount;
    public int EnemySpawnAmount => enemySpawnAmount;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLevelManager();
    }

    protected virtual void FixedUpdate()
    {
        this.CanCountTime();
        this.CountTime();
        this.CheckLevelUp();
        this.UpdateStat();
    }

    //=====================================Load Component==========================================
    protected virtual void LoadLevelManager()
    {
        if (this.levelManager != null) return;
        this.levelManager = transform.parent.GetComponent<LevelManager>();
        Debug.Log(transform.name + ": LoadLevelManager", transform.gameObject);
    }

    //==========================================Bool===============================================
    protected virtual bool CanCountTime()
    {
        return true;
    }

    //==========================================Level==============================================
    protected virtual void CountTime()
    {
        if (!this.CanCountTime()) return;
        this.currTime += Time.fixedDeltaTime;
    }

    protected virtual void CheckLevelUp()
    {
        if (this.currLevel >= this.levelTimes.Count) return;
        if (this.currTime < this.levelTimes[this.currLevel]) return;
        this.currLevel++;
        Debug.Log(transform.name + ": Level" + currLevel, transform.gameObject);
    }

    //=======================================Other Func============================================
    protected virtual void DefaultStat()
    {
        if (this.levelManager == null) Debug.LogError(transform.name + ": No levelManager", transform.gameObject);
        //Level
        this.currLevel = 0;
        this.levelTimes = this.levelManager.LevelSO.LevelTimes;
    }

    protected virtual void UpdateStat()
    {
        if (this.levelManager == null) Debug.LogError(transform.name + ": No levelManager", transform.gameObject);
        if (this.levelManager.LevelSO.EnemySpawnAmountByLevel.Count != this.levelManager.LevelSO.LevelTimes.Count) Debug.LogError(transform.name + ": EnemySpawnAmountByLevel must equal levelTimes", transform.gameObject);
        this.enemySpawnAmount = this.levelManager.LevelSO.EnemySpawnAmountByLevel[this.currLevel];
    }
}
