using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreOPen : MonoBehaviour
{
    MenuCanvasSingleton menu;


    private void Start()
    {

        menu = MenuCanvasSingleton.instance;

    }
    private void OnMouseDown()
    {

        print(gameObject.name);

        menu.GetComponent<MenuScript>(). ToggleStore();
    }
}
