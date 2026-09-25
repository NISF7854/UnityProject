
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor; 
#endif
using UnityEngine;

public class Inventory : MonoBehaviour,ISaveManager
{
    public static Inventory Instance;

    public List<InventoryItem> inventoryItems;
    public List<InventoryItem> stashItems;
    public List<InventoryItem> equipmentItems;

    public Dictionary<ItemData, InventoryItem> inventoryItemsDictionary;
    public Dictionary<ItemData,InventoryItem> stashItemsDictionary;
    public Dictionary<ItemData_Equipment, InventoryItem> equipmentDictionary;
   

    public UI_ItemSlot[] inventoryItemSlots;
    public UI_ItemSlot[] stashItemSlots;
    public UI_EquipmentSlot[] equipmentSlots;
    
    
    public Transform inventroyParent;
    public Transform stashParent;
    public Transform equipmentParent;

    [Header("Data base")]
    public string[] assetNames;
    public List<ItemData> itemDataBase;
    public List<InventoryItem> loadedItems;


    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        
    }

    public void Start()
    {
        inventoryItems = new List<InventoryItem>();
        inventoryItemsDictionary = new Dictionary<ItemData, InventoryItem>();
        
        stashItems = new List<InventoryItem>();
        stashItemsDictionary = new Dictionary<ItemData, InventoryItem>();

        equipmentItems = new List<InventoryItem>();
        equipmentDictionary = new Dictionary<ItemData_Equipment, InventoryItem>();

        
        inventoryItemSlots = inventroyParent.GetComponentsInChildren<UI_ItemSlot>();
        stashItemSlots = stashParent.GetComponentsInChildren<UI_ItemSlot>();
        equipmentSlots = equipmentParent.GetComponentsInChildren<UI_EquipmentSlot>();

        
    }

    public void EquipItem(ItemData _itemData)
    {
        InventoryItem newItem = new InventoryItem(_itemData);
        ItemData_Equipment newItemData = _itemData as ItemData_Equipment;

        ItemData_Equipment oldEquipment = null;
        
        foreach(KeyValuePair<ItemData_Equipment, InventoryItem> item in equipmentDictionary )
        {
            if(item.Key.equipmentType == newItemData.equipmentType )
            {
                oldEquipment = item.Key; 
                break;
            }

        }
        if (oldEquipment != null)
        {
            if (equipmentDictionary.TryGetValue(oldEquipment, out InventoryItem value))
            { 
                inventoryItems.Add(value);
                inventoryItemsDictionary.Add(oldEquipment, value);

                equipmentItems.Remove(value);
                equipmentDictionary.Remove(oldEquipment);
                oldEquipment.RemoveModifiers();//卸下装备Remove属性
            }
        }


        RemoveData(_itemData);

        equipmentItems.Add(newItem);
        equipmentDictionary.Add(newItemData, newItem);
        newItemData.AddModifiers();//装备装备时Add属性

        UpdataItemSlotsUI();
    }


    public void UpdataItemSlotsUI()
    {
        for(int i =0; i <inventoryItemSlots.Length;i++)
        {
            inventoryItemSlots[i].CleanUpSlots();
        }
        for(int i = 0;i<stashItemSlots.Length;i++)
        {
            stashItemSlots[i].CleanUpSlots();
        }
        for(int i =0; i < equipmentSlots.Length;i++)
        {
            equipmentSlots[i].CleanUpSlots();
        }



        for(int i = 0; i < inventoryItems.Count; i++)
        {
            inventoryItemSlots[i].UpdataSlots(inventoryItems[i]);   
        }
        for(int i = 0;i< stashItems.Count; i++)
        {
            stashItemSlots[i].UpdataSlots(stashItems[i]);
        }
        foreach(KeyValuePair<ItemData_Equipment, InventoryItem> item in equipmentDictionary)
        {
            for(int i =0;i<equipmentSlots.Length;i++)
            {
                if(item.Key.equipmentType == equipmentSlots[i].slotType) 
                {
                    equipmentSlots[i].UpdataSlots(item.Value);

                }
            }
        }
    }

    public void AddData(ItemData _item)
    {
        if (_item.type == ItemType.Equipment)
        {
            AddToInventory(_item);
        }
        else if(_item.type == ItemType.Material)
        {
            AddToStash(_item);
        }

    }

    private void AddToStash(ItemData _item)
    {
        if (stashItemsDictionary.TryGetValue(_item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            newItem.AddStack();
            stashItems.Add(newItem);
            stashItemsDictionary.Add(_item, newItem);
        }
        UpdataItemSlotsUI();
    }

    private void AddToInventory(ItemData _item)
    {
        if (inventoryItemsDictionary.TryGetValue(_item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            newItem.AddStack();
            inventoryItems.Add(newItem);
            inventoryItemsDictionary.Add(_item, newItem);
        }
        UpdataItemSlotsUI();
    }

    public void RemoveData(ItemData _item)
    {
        if(inventoryItemsDictionary.TryGetValue(_item, out InventoryItem value))
        {
            if(value.stackSize > 1 )
            {
                value.RemoveStack();
            }
            else
            {
                inventoryItems.Remove(value);
                inventoryItemsDictionary.Remove(_item);
            }
        }
        UpdataItemSlotsUI();

        if (stashItemsDictionary.TryGetValue(_item, out InventoryItem value1))
        {
            if (value1.stackSize > 1)
            {
                value1.RemoveStack();
            }
            else
            {
                inventoryItems.Remove(value);
                inventoryItemsDictionary.Remove(_item);
            }
        }
        UpdataItemSlotsUI();

    }

    public ItemData_Equipment GetEquipmentDataByType(EquipmentType _type)
    {
        ItemData_Equipment itemData = null;
        foreach (var item in equipmentDictionary)
        {
            if(item.Key.equipmentType == _type)
            {
                itemData = item.Key;
                break;
            }

        }
        return itemData;
    }

    //使用药水
    public void UseFlask()
    {

        if(GetEquipmentDataByType(EquipmentType.Flask) != null)
        {
            GetEquipmentDataByType(EquipmentType.Flask).ExecuteAllEffectsWhenActive();
        }
    }

    public void LoadData(GameData _data)
    {
        GetItemDataBase();
        foreach(KeyValuePair<string,int> pair in _data.inventory)
        {
            foreach(var item in GetItemDataBase()) 
            {
                if(item != null && item.id == pair.Key)
                {
                    InventoryItem itemToLoad = new InventoryItem(item);
                    itemToLoad.stackSize = pair.Value;

                    loadedItems.Add(itemToLoad);
                }
            }
        }

        LoadStartingItems();

        foreach(var id in _data.equippedItems)
        {
            foreach(var item in GetItemDataBase())
            {
                if(item.id == id && item != null)
                {
                    EquipItem(item);
                }
            }
        }


    }

    public void SaveData(ref GameData _data)
    {
        _data.inventory.Clear();

        foreach(KeyValuePair<ItemData,InventoryItem> pair in inventoryItemsDictionary)
        {
            _data.inventory.Add(pair.Key.id, pair.Value.stackSize);
        }
        foreach (KeyValuePair<ItemData, InventoryItem> pair in stashItemsDictionary)
        {
            _data.inventory.Add(pair.Key.id, pair.Value.stackSize);
        }

        foreach(KeyValuePair<ItemData_Equipment, InventoryItem> pair in equipmentDictionary)
        {
            _data.equippedItems.Add(pair.Key.id);
        }
    }

    private List<ItemData> GetItemDataBase()
    {
        itemDataBase = new List<ItemData>();
#if UNITY_EDITOR
        assetNames = AssetDatabase.FindAssets("", new[] { "Assets/Data/ItemData" });
#endif
        foreach (string assetName in assetNames) 
        {
#if UNITY_EDITOR
            var assetPath = AssetDatabase.GUIDToAssetPath(assetName);
            var itemData = AssetDatabase.LoadAssetAtPath<ItemData>(assetPath);
            itemDataBase.Add(itemData);
#endif
        }
        return itemDataBase;
    }

    //加载初始物品或存档物品
    private void LoadStartingItems()
    {
        if(loadedItems.Count >0)
        {
            foreach(var item in loadedItems)
            {
                for(int i = 0;i < item.stackSize ; i++)
                {
                    AddData(item.itemData);
                }
            }
        }

    }
}
