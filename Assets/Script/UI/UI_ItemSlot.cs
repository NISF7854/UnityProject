using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemSlot : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler, IPointerExitHandler
{
    

    [SerializeField] private Image itemImage;
    [SerializeField] protected TextMeshProUGUI itemText;

    public UI ui;
    

    public InventoryItem item;



    private void Awake()
    {
        ui= GetComponentInParent<UI>();
    }


    public void UpdataSlots(InventoryItem _item)
    {
        item = _item;
        if (item != null)
        {
            itemImage.sprite = item.itemData.icon;
            itemImage.color = new Color(255, 255, 255, 1);
            if (item.stackSize > 1)
            {
                itemText.text = item.stackSize.ToString();
            }
            else
            {
                itemText.text = "";
            }
        }
       
        
    }

    public void CleanUpSlots()
    {
        itemImage.sprite = null;
        itemText.text = "";
        item = null;
        itemImage.color = Color.clear;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if(item == null)
        {
            return;
        }

        if(item.itemData.type == ItemType.Equipment) 
        {
            Inventory.Instance.EquipItem(item.itemData);
        }
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (item == null)
        {
            ui.HideItemToolTip();
            return;
        }   
        ui.ShowItemToolTip(item.itemData);
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (item == null)
            return;

        ui.HideItemToolTip();
    }

    
}
