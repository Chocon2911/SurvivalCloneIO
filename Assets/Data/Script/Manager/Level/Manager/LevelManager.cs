using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : HuyMonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    [SerializeField] protected LevelSO levelSO;
    public LevelSO LevelSO => levelSO;

    [Header("Stat")]
    [SerializeField] protected List<float> timeLevel;
    public List<float> TimeLevel => timeLevel;

    [SerializeField] protected float timeTimer = 0;
    public float TimeTimer => timeTimer;

    [SerializeField] protected int currLevel;
    public int CurrentLevel => currLevel;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One LevelManager exists only!", transform.gameObject);
            return;
        }
        instance = this;

        base.Awake();
    }

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected virtual void Update()
    {
        this.CheckLevel();
    }

    //========================================================Checker================================================
    protected virtual void CheckLevel()
    {
        if (this.timeTimer < this.timeLevel[this.currLevel])
        {
            this.timeTimer += Time.deltaTime;
            return;
        }

        this.currLevel += 1;
        EnemyManager.Instance.SpawnEnemy.LevelUp(currLevel);
        Debug.Log(transform.name + ": LevelUp", transform.gameObject);
    }

    //======================================================Other Func===============================================
    protected virtual void DefaultStat()
    {
        this.timeTimer = 0;
        this.currLevel = 0;
        this.timeLevel = this.levelSO.TimeLevel;
    }
}
