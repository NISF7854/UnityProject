using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    //玩家钱币
    public int currency;

    //玩家仓库
    public MyDictionary<string, int> inventory;
    //已装备物品
    public List<string> equippedItems;
    public GameData()
    {
        this.currency = 0;
        inventory = new MyDictionary<string, int>();
        equippedItems = new List<string>();
    }
}
