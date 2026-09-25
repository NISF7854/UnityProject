using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    bool isActive = false;

    [SerializeField] public UI_ItemToolTip itemToolTip;
    [SerializeField] public UI_StateToolTip stateToolTip;

    [SerializeField] public UI_InGame inGame;
    [SerializeField] public UI_FadeScreen fadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenMenu();
    }

    public void SwitchTo(GameObject _menu)
    {
        for(int i =0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        if(_menu != null)
        {
            _menu.SetActive(true);
        }
    }

    public void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            if (isActive == false)
            {
                //ÔÝÍ£ÓÎÏ·
                GameManager.Instance.PauseGame(true);

                isActive = true;
                itemToolTip.gameObject.SetActive(false);
                stateToolTip.gameObject.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(true);
                Inventory.Instance.UpdataItemSlotsUI();

                //Òþ²ØInGameUI
                inGame.gameObject.SetActive(false);
            }
            else
            {
            
                GameManager.Instance.PauseGame(false);

                isActive = false;
                itemToolTip.gameObject.SetActive(false);
                stateToolTip.gameObject.SetActive(false);
                for (int i = 0; i < 4; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                //ÏÔÊ¾InGameUI
                inGame.gameObject.SetActive(true);
            }
        }    
    }

    public void ShowItemToolTip(ItemData _itemData)
    {
        itemToolTip.gameObject.SetActive(true);
        itemToolTip.Setup(_itemData);
    }
    public void HideItemToolTip()
    {
        itemToolTip.gameObject.SetActive(false);
    }

    public void ShowStateToolTip(StatisticType _type)
    {
        stateToolTip.Setup(_type);
        stateToolTip.gameObject.SetActive(true);
    }
    public void HideStateToolTip()
    {
        stateToolTip.gameObject?.SetActive(false);
    }


   


}
