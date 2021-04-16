using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector3.MoveTowards(transform.position, new Vector3(player.position.x,player.position.y + offsetY, -10) , 1f);
    }
}
