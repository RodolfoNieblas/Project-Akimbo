using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEnemy : MonoBehaviour //this goes on the potion enemy
{
    public float timer;
    public GameObject theProjectile;
    private float resetTimer;
    

    void Start(){
        resetTimer = timer;
        timer = 0f;
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            Instantiate(theProjectile, transform.position, transform.rotation);
            timer = resetTimer;
        }
    }
}
