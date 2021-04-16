using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject btn;
    public int amountOfItems;
    MenuCanvasSingleton menu;
    Inventory inventory;
    bool itemPickedUp;

    private void Start()
    {
        menu = MenuCanvasSingleton.instance;
        inventory = menu.GetComponent<Inventory>();
    }


    private void Update()
    {
        if (itemPickedUp){
            MoveToBP();            
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemPickedUp = false;
        if (collision.CompareTag("Player") && !itemPickedUp)
        {
            inventory.CheckSlotAvailability(btn, btn.name, amountOfItems);
            MoveToBP();
            itemPickedUp = true;
            //

        }
    }

    private void OnMouseDown()
    {
        itemPickedUp = false;
        if (!itemPickedUp)
        {
            inventory.CheckSlotAvailability(btn, btn.name, amountOfItems);
            MoveToBP();
            itemPickedUp = true;
            //

        }
    }


    public void MoveToBP()
    {
        transform.position = Vector3.MoveTowards(transform.position, inventory.bp.transform.position, 300 * Time.deltaTime);
        float dist = Vector2.Distance(transform.position, inventory.bp.transform.position);
        if( dist < 1f)
        {
            itemPickedUp = false;
            Destroy(gameObject);
        }
        
      //  Destroy(gameObject);
    }

}
