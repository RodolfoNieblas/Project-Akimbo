using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour //This script goes on the soul
{
    public float soulSpeed = 1f; //Just in case we forget to set it in game

    private Transform playerTM;
    private Rigidbody2D soulRB;
    private SpriteRenderer soulSR;
    private float soulX;
    private float soulY;
    private float playerX;
    private float playerY;
    private float soulVelX;
    private float soulVelY;

    public float  leftShoulderX = 0.3f;
    public float  rightShoulderX = 0.3f;
    public float shoulderY = 0.7f;
    private float leftShoulderXprivate;
    private float rightShoulderXprivate;
    private float shoulderYprivate;

    void Start()
    {
        playerTM = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        soulRB = GetComponent<Rigidbody2D>();
        soulSR = GetComponent<SpriteRenderer>();
        soulSR.color = Color.yellow;
    }


    void Update()
    {
        soulX = this.transform.position.x;
        soulY = this.transform.position.y;

        playerX = playerTM.position.x;
        playerY = playerTM.position.y;

        leftShoulderXprivate = (playerX - leftShoulderX) - soulX;
        rightShoulderXprivate = (playerX + rightShoulderX) - soulX;
        shoulderYprivate = (playerY + shoulderY) - soulY;

        if((playerX - soulX) <= 0f) //if velocity vector is positive, go on left shoulder
        {
            soulRB.velocity = new Vector2(rightShoulderXprivate * soulSpeed, shoulderYprivate * soulSpeed);
        } 
        else if((playerX - soulX) > 0f) //if velocity vector is negative, go on right shoulder
        {
            soulRB.velocity = new Vector2(leftShoulderXprivate * soulSpeed, shoulderYprivate * soulSpeed);
        }
        
    }
}
