﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script should be applied to an enemy who you want to
// have a spreadshot fire pattern.  All public variables
// are to adjust the behavior of the shots except for
// projectile which requires a bullet prefab in its slot
public class Slime_enemy_spreadshot : MonoBehaviour
{
    public float projectile_speed;
    public int projectile_spread_angle;
    private int angle_in_spread;
    public int num_of_projectiles;
    Vector2 move_dir;
    
    // the target aka the Player
    GameObject target;
    [SerializeField] GameObject projectile;

    public float fire_rate;
    float no_firing;

    // Start is called before the first frame update
    void Start()
    {
        no_firing = Time.time;
        target = GameObject.Find("Player");
        // to prevent errors potentially caused by inputting negative number
        angle_in_spread = -Mathf.Abs(projectile_spread_angle);
    }

    // Update is called once per frame
    void Update()
    {
        // check if it's time to fire and spawn a bullet if it is
        if (Time.time > no_firing)
        {
            angle_in_spread = -Mathf.Abs(projectile_spread_angle);
            for (int i = 0; i < num_of_projectiles; i++)
            {
                CreateBullet(angle_in_spread);
                angle_in_spread += (2 * Mathf.Abs(projectile_spread_angle) / (num_of_projectiles - 1));
            }

            no_firing = Time.time + fire_rate;
        }
    }

    private void CreateBullet(float angleOffset)
    {
        GameObject bullet = Instantiate<GameObject>(projectile);
        bullet.transform.position = transform.position;
        move_dir = (target.transform.position - transform.position).normalized * projectile_speed;

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        // pushes the bullet along the vector determined by the direction
        // toward the player and an offset given as an argument to the function
        rigidbody.AddForce(Quaternion.AngleAxis(angleOffset, Vector3.forward) * move_dir * 25.0f);
    }

}
