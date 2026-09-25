using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UI_ItemToolTip : MonoBehaviour
{
    
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemEffetcDescription;
    public TextMeshProUGUI itemStatistic;

    public StringBuilder strb;
    
   
    ItemData itemData;

    private void Update()
    {
    }

    private void Awake()
    {
        
    }

    public void Setup(ItemData _itemData)
    {
        ItemData_Equipment itemData_Equipment = _itemData as ItemData_Equipment;
        itemData = _itemData;  
        itemName.text = _itemData.name;
        itemType.text= itemData_Equipment.equipmentType.ToString();
        itemEffetcDescription.text = itemData_Equipment.effectDescription;
        itemStatistic.text = itemData_Equipment.GetStatisticText();


    }

   

}
