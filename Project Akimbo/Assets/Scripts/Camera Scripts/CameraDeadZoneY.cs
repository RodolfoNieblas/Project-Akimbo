﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDeadZoneY : MonoBehaviour
{
    //need variable for boolean in camera follow
    private CameraFollow camerafollow;

    void Start(){
        camerafollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            camerafollow.cameraFollowingY = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            camerafollow.cameraFollowingY = true;
        }
    }
}
