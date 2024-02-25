using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : HuyMonoBehaviour
{
    [SerializeField] protected GameManager gameManager;
    public GameManager GameManager => gameManager;

    [Header("Stat")]
    [SerializeField] protected bool isGameOver;
    public bool IsGameOver => isGameOver;

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGameManager();
    }

    protected virtual void LateUpdate()
    {
        this.CheckPlayerLose();
    }

    //=================================Load Component==============================================
    protected virtual void LoadGameManager()
    {
        if (this.gameManager != null) return;
        this.gameManager = transform.GetComponent<GameManager>();
        Debug.Log(transform.name + ": LoadGameManager", transform.gameObject);
    }

    //====================================Checker==================================================
    protected virtual void CheckPlayerLose()
    {
        if (this.gameManager.ActivePlayers.Count > 0 || this.isGameOver) return;
        this.isGameOver = true;
        StartCoroutine(LoadSceneAfterTime(3));
    }

    //===================================Other Func================================================
    protected virtual IEnumerator LoadSceneAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        this.isGameOver = false;
        SceneManager.LoadScene(0);
    }

    protected virtual void DefaultStat()
    {
        this.isGameOver = false;
    }
}
