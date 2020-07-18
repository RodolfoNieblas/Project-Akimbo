using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Put on an enemy where a snakeshot pattern is desired
// implemented using a different method than spreadshot.
// The enemy should shoot within a cone which has its base's midpoint
// on the player.
public class enemy_snakeshot : MonoBehaviour
{
    public float projectile_speed;
    // determines the outer boundaries of the cone which
    // the enemy will shoot bullets in
    public int projectile_spread_angle;
    // determines the number of projectiles which will be shot
    // on one sweep from -projectile_spread_angle degrees to
    // +projectile_spread_angle degrees
    public int num_of_projectiles;
    // determines how long the enemy will shoot for before pausing
    public float shooting_length;

    // keeps track of what angle we want to offset the enemy's
    // shot towards the player by
    private int angle_in_spread;
    // the vector from the enemy straight to the player
    private Vector2 to_player;
    
    // the target aka the Player
    private GameObject target;
    // what will be fired towards the player
    [SerializeField] private GameObject projectile;

    // counter to keep track of the time enemy will not fire for
    private float no_firing;
    // keeps track of what direction the sweep through the cone is going
    private bool up = true;

    // Start is called before the first frame update
    void Start()
    {
        shooting_length = Mathf.Abs(shooting_length);
        projectile_spread_angle = Mathf.Abs(projectile_spread_angle);
        no_firing = -10;
        target = GameObject.Find("Player");

        // to prevent errors potentially caused by inputting negative number
        angle_in_spread = -projectile_spread_angle;

        // repeatedly calls the Shoot function immediately every
        // 1/10th of a second
        InvokeRepeating("Shoot", 0f, 0.1f);
    }

    private void Shoot()
    {
        if (no_firing < 0)
        {
            CreateBullet(angle_in_spread);
            if (up)
            {
                // increment the angle at whichthe next bullet will be shot
                angle_in_spread += (2 * projectile_spread_angle / (num_of_projectiles - 1));
                // sweep in the other direction once we reach the upper bound
                // of the cone
                if (angle_in_spread >= projectile_spread_angle)
                    up = false;
            }
            else
            {
                angle_in_spread -= (2 * projectile_spread_angle / (num_of_projectiles - 1));
                if (angle_in_spread <= -projectile_spread_angle)
                    up = true;
            }

            // incremented in this manner to keep variable names meaningful
            no_firing += 1/shooting_length;
        }
        else
        {
            // since this function is called every tenth of a seond, the below
            // stops creating bullets for one second
            no_firing++;
            if (no_firing >= 10)
                no_firing = -10;
        }
    }

    private void CreateBullet(float angleOffset)
    {
        GameObject bullet = Instantiate<GameObject>(projectile);
        bullet.transform.position = transform.position;
        to_player = (target.transform.position - transform.position).normalized * projectile_speed;

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        // pushes the bullet along the vector determined by the direction
        // toward the player and an offset given as an argument to the function
        rigidbody.AddForce(Quaternion.AngleAxis(angleOffset, Vector3.forward) * to_player * 25.0f);
    }
}
