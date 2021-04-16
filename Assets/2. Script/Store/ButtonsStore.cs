using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonsStore : MonoBehaviour
{

    public int price;
    Text priceTxt;
    public string itemName;
    public int amount;
    public GameObject btn;
    MenuCanvasSingleton menu;
    Inventory inventory;
    // Start is called before the first frame update
    private void Start()
    {
        priceTxt = GetComponentInChildren<Text>();
        priceTxt.text = "$ " + price;
        itemName = btn.name;
        menu = MenuCanvasSingleton.instance;
        inventory = menu.GetComponent<Inventory>();
    }

    // Update is called once per frame


    public void BuyItem()
    {   
        inventory.CheckSlotAvailability(btn, btn.name, amount);
    }


}
