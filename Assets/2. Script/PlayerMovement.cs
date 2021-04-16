using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        Flip(); ;
    }

    private void MovePlayer()
    {
       

        float velX = Input.GetAxisRaw("Horizontal");
        float velY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2( velX * speed * Time.deltaTime, rb.velocity.y);
    }

    void Flip()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        } 
    }

}
