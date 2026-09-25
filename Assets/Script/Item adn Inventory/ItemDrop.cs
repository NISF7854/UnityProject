using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject dropPrefab;
    //µÙ¬‰ŒÔ∫Õ∏≈¬ 
    [SerializeField] public List<MyKeyValuePair<ItemData, float>> dropPool;

    public void DropItem()
    {
       

        foreach(var item in dropPool)
        {
            if(Random.Range(0f,1f) < item.value)
            {
                GameObject newObject = Instantiate(dropPrefab, transform.position, Quaternion.identity);


                Vector2 randomVelocity = new Vector2(Random.Range(-5, 5), Random.Range(10, 15));

                newObject.GetComponent<ItemObject>().SetupItem(item.key, randomVelocity);
            }
        }
       
    }



}
