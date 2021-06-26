using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory2/Items")]
[System.Serializable]

public class Inventory2Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public Sprite itemImageClose;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;

    public void Use ()
    {

            Debug.Log("Using " + itemName);
            thisEvent.Invoke();

    }

    public void DecreaseAmount(int amountToDecrease)
    {
        numberHeld -= amountToDecrease;
        if (numberHeld< 0)
        {
            numberHeld = 0;
        }
    }
}
