using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UI_StatisticShow : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    public TextMeshProUGUI text;
    public StatisticType statisticType;

    public UI ui;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        ui = GetComponentInParent<UI>();
    }

    public void OnValidate()
    {
        gameObject.name = "Statistic_" + statisticType.ToString();
    }


    void Start()
    {
        //UpdateStatisticShow();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStatisticShow();
    }

    public void UpdateStatisticShow()
    {
        PlayerStatistic playerStatistic = PlayerManager.instance.player.statistic;

        if (playerStatistic != null)
        {
            text.text = playerStatistic.GetStatisticByType(statisticType).GetValue().ToString();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.ShowStateToolTip(statisticType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ui.HideStateToolTip();
    }
}
