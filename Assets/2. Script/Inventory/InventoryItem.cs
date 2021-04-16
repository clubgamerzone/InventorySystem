using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : Inventory
{
    public string itemName;
    public int amount;

    public InventoryItem(string nameOfItem, int amountOfItem)
    {
        itemName = nameOfItem;
        amount = amountOfItem;
    }
}
