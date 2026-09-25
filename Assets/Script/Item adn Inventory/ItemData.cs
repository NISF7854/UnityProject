using UnityEditor;
using UnityEngine;

public enum ItemType
{
    Material,
    Equipment
}

[CreateAssetMenu(fileName ="New Item Data",menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public ItemType type;

    public string itemName;
    public Sprite icon;

    public string id;

    public void OnValidate()
    {
#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
#endif
    }

}
