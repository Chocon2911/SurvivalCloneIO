using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIManager : HuyMonoBehaviour
{
    private static HealthBarUIManager instance;
    public static HealthBarUIManager Instance;

    [SerializeField] protected Slider slider;
    public Slider Slider => slider;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": One HealthBarUIManager Only", transform.gameObject);
            return;
        }
        instance = this;

        base.Awake();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }
    protected virtual void Update()
    {
        if (GameManager.Instance.ActivePlayers.Count == 0) return;
        DamageReceiver playerDamageReceiver = GameManager.Instance.ActivePlayers[0].Find("DamageReceiver").GetComponent<DamageReceiver>();
        float health = playerDamageReceiver.Health;
        this.SetHealth(health);
    }

    //=======================================Load Component========================================
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", transform.gameObject);
    }

    //===========================================Public============================================
    protected virtual void SetHealth(float health)
    {
        this.slider.value = health;
    }
}
