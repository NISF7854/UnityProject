using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EquipmentSlot : UI_ItemSlot
{
    public EquipmentType slotType;

    public void Update()
    {
        if(slotType == EquipmentType.Flask)
        {
            ShowFlaskAmount();
        }
        
    }

    private void ShowFlaskAmount()
    {
        //œ‘ æ“©∆ø ˝¡ø
        if (Inventory.Instance.GetEquipmentDataByType(EquipmentType.Flask) != null)
        {
            ItemData_Equipment newData = item.itemData as ItemData_Equipment;
            FlaskEffect newEffect = newData.itemEffects[0] as FlaskEffect;
            if (newEffect != null)
            {
                itemText.text = newEffect.amount.ToString();
            }
        }
       
    }

    public void OnValidate()
    {
        gameObject.name = "Equipment_"+slotType.ToString();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {

    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }
}


