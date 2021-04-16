using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsInventory : MonoBehaviour
{
    MenuCanvasSingleton menu;
    Inventory inventory;

    private void Start()
    {
        menu = MenuCanvasSingleton.instance;
        inventory = menu.GetComponent<Inventory>();
    }

    public void UseItem()
    {
        inventory.UseInventoryItems(gameObject.name);
    }
}
