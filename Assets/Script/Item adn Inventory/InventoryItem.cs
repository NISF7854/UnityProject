using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem 
{
    public ItemData itemData;
    public int stackSize;

    public InventoryItem(ItemData _itemData)
    {
        itemData = _itemData;
    }
    
    public void AddStack()
    {
        stackSize++;
    }
    public void RemoveStack()
    {
        stackSize--;
    }

}
