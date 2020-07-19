using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDeadZoneX : MonoBehaviour
{
    //need variable for boolean in camera follow
    private CameraFollow camerafollow;

    void Start(){
        camerafollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            camerafollow.cameraFollowingX = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            camerafollow.cameraFollowingX = true;
        }
    }
}
