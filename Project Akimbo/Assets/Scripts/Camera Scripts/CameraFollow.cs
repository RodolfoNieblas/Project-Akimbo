using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour //this goes on the main camera
{
    
    public float dampTime = 0.4f; //for smoothness
    public float zAxis = -20f;
    public bool cameraFollowingX = true; //this is being manipulated on another script
    public bool cameraFollowingY = true; //this is being manipulated on another script
    private Transform Player;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero; 
    

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        

    }
    
    void Update()
    {
        

        if(cameraFollowingX == true && cameraFollowingY == true)
        {
            cameraPos = new Vector3(Player.position.x, Player.position.y, zAxis);
        }
        else if(cameraFollowingY == false && cameraFollowingX == false)
        {
            cameraPos = new Vector3(transform.position.x, transform.position.y, zAxis);
        }
        else if(cameraFollowingX == false)
        {
            cameraPos = new Vector3(transform.position.x, Player.position.y, zAxis);
        }
        else if(cameraFollowingY == false)
        {
            cameraPos = new Vector3(Player.position.x, transform.position.y, zAxis);
        }
        

        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, dampTime);
    }
}
