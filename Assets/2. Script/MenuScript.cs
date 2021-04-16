using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public GameObject playerInv;
    public GameObject storeInv;
    bool active;
    bool storeActive;
    // Start is called before the first frame update


    public void ToggleInventory()
    {      

        if (!active)
        {
  
            playerInv.GetComponent<Animator>().SetBool("Show", true);
            active = true;


        }
        else
        {
     
            playerInv.GetComponent<Animator>().SetBool("Show", false);
            active = false;

            if (storeInv.activeSelf)
            {
                storeInv.GetComponent<Animator>().SetBool("Show", false);
                storeActive = false;
            }
        }
    }

    public void ToggleStore()
    {


        if (!active)
        {

            storeInv.GetComponent<Animator>().SetBool("Show", true);
            storeActive = true;
            playerInv.GetComponent<Animator>().SetBool("Show", true);
            active = true;

        }
        else
        {

            storeInv.GetComponent<Animator>().SetBool("Show", false);
            storeActive = false;

            playerInv.GetComponent<Animator>().SetBool("Show", false);
            active = false;
        }
    }

}
