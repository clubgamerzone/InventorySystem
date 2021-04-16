using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject[] slots;
    public GameObject bp;
    bool isInstantiated;


    public Dictionary<string, int> inventoryItems = new Dictionary<string, int>();




    /// <summary>
    /// Creates the Button for the inventory, add the name to a dictionary and sets the amount.
    /// </summary>
    /// <param name="itemToAdd"></param>
    /// <param name="itemName"></param>
    /// <param name="itemAmount"></param>
    public void CheckSlotAvailability(GameObject itemToAdd, string itemName, int itemAmount )
    {
        isInstantiated = false;
        for (int i = 0; i < slots.Length; i++)
        {
            

            if (slots[i].transform.childCount > 0)
            {
                slots[i].GetComponent<SlotScript>() . isUsed = true;
            }
            else if(!isInstantiated && !slots[i].GetComponent<SlotScript>().isUsed)
            {
               
                if (!inventoryItems.ContainsKey(itemName)){

                    GameObject item = Instantiate(itemToAdd, slots[i].transform.position, Quaternion.identity);
                    item.transform.SetParent(slots[i].transform, false);
                    item.transform.localPosition = new Vector3(0, 0, 0);
                    item.name = item.name.Replace("(Clone)","");
                    isInstantiated = true;
                    slots[i].GetComponent<SlotScript>().isUsed = true;
                    inventoryItems.Add(itemName, itemAmount);

                    item.GetComponentInChildren<Text>().text = itemAmount.ToString();
                    break;
                }
                else
                {
                    for (int j = 0; j < slots.Length; j++)
                    {
                        if(slots[j].transform.GetChild(0).gameObject.name == itemName)
                        {
                            inventoryItems[itemName] += itemAmount;


                            slots[j].transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = inventoryItems[itemName].ToString();
                            break;
                        }
                    }                   

                    break;
                    
                }

               

            }
                  
        }
        foreach (KeyValuePair<string, int> item in inventoryItems)
        {
            print(item.Key + " " + item.Value);
        }

    }

    public void UseInventoryItems(string itemName)
    {
        for (int j = 0; j < slots.Length; j++)
        {
            if (slots[j].transform.GetChild(0).gameObject.name == itemName)
            {
                inventoryItems[itemName] --;


                slots[j].transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = inventoryItems[itemName].ToString();

                if (inventoryItems[itemName] <= 0)
                {
                    Destroy(slots[j].transform.GetChild(0).gameObject);
                    slots[j].GetComponent<SlotScript>().isUsed = false;
                    inventoryItems.Remove(itemName);
                    ReorganizeInventory();
                }
                break;
            }
        }
    }

    private void ReorganizeInventory()
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            if (!slots[i].GetComponent<SlotScript>().isUsed)// si slot cero está vacío corro jota buscando uno que esté lleno
            {

                for (int j = i + 1; j < slots.Length - 1; j++)
                {
                    if (slots[j].GetComponent<SlotScript>().isUsed)
                    {
                        Transform itemToMove = slots[j].transform.GetChild(0).transform;
                        itemToMove.transform.SetParent(slots[i].transform, false);
                        itemToMove.transform.localPosition = new Vector3(0, 0, 0);
                        slots[i].GetComponent<SlotScript>().isUsed = true;
                        slots[j].GetComponent<SlotScript>().isUsed = false;
                        break;
                    }

                }




            }
           

            
        }
    }
}
