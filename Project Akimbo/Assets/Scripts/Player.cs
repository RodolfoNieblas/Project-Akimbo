using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D playerRB;

    void Start()
    {
        
        playerRB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //Code for Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // if player moves anywhere then the velocity vector = speed
        if (moveHorizontal > 0.5f || moveHorizontal < -0.5f || moveVertical > 0.5f || moveVertical < -0.5f)  
        {
            playerRB.velocity = new Vector2(moveHorizontal, moveVertical).normalized * speed;
        }
        
        // When we release 'a' or 'd' then the player stops moving horizontally
        else if (moveHorizontal < 0.5f && moveHorizontal > -0.5f) 
        { 
            playerRB.velocity = new Vector2(0f, moveVertical).normalized;
        }

        // When we release 'w' or 's' then the player stops moving vertically
        else if (moveVertical < 0.5f && moveVertical > -0.5f) 
        {
            playerRB.velocity = new Vector2(moveHorizontal, 0f).normalized;
        }
    }
}
