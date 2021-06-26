using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory2 playerInventory2;
    [SerializeField] private Inventory2Item thisItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }

    }

    void AddItemToInventory()
    {
        if(playerInventory2 && thisItem)
        {
            if(playerInventory2.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            }
            else
            {
                playerInventory2.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }
}
