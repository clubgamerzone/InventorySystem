using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasSingleton : MonoBehaviour
{
    public static MenuCanvasSingleton instance;

    private void Awake()
    {
        instance = this;
    }
}
