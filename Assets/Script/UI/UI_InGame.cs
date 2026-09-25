using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerStatistic playerStatistic;
    [SerializeField] protected Slider slider;//ÑªÌõ

    [SerializeField] private Image dashCD;


    
    void Start()
    {
        player = PlayerManager.instance.player;
        playerStatistic = PlayerManager.instance.player.statistic;
    }

    
    void Update()
    {
        UpdateHealthBar();
        UpdateDashImage();
    }


    void UpdateHealthBar()
    {
        slider.maxValue = playerStatistic.maxHealth.GetValue();
        slider.value = playerStatistic.currentHealth;
    }

    void UpdateDashImage()
    {
        dashCD.fillAmount = player.dashTimer / player.dashCD;
    }
}

