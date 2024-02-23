using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : HuyMonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    [SerializeField] protected LevelByTime levelByTime;
    public LevelByTime LevelByTime => levelByTime;

    [SerializeField] protected LevelSO levelSO;
    public LevelSO LevelSO => levelSO;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": Only one LevelManager can exists", transform.gameObject);
            return;

        }
        instance = this;

        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLevelByTime();
    }

    //========================================Load Component=======================================
    protected virtual void LoadLevelByTime()
    {
        if (this.levelByTime != null) return;
        this.levelByTime = transform.Find("ByTime").GetComponent<LevelByTime>();
        Debug.Log(transform.name + ": LoadLevelByTime", transform.gameObject);
    }

}
