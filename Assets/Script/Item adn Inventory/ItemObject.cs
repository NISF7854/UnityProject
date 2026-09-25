using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private Vector2 velocity;

    [SerializeField] private ItemData itemData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    private void OnValidate()
    {
        if(itemData == null) 
        {
            return;
        }

        gameObject.name = "Item_" + itemData.name;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = itemData.icon;
    }

    void Update()
    {
        
    }
    public void SetupItem(ItemData _itemData,Vector2 _velocity)
    {
        itemData = _itemData;
        rb.velocity = _velocity;
        gameObject.name = "Item_" + itemData.name;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = itemData.icon;
    }



    public void PickUpItem()
    {
        Inventory.Instance.AddData(itemData);
        Destroy(gameObject);
    }
}
