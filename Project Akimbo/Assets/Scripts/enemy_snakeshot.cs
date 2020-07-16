using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_snakeshot : MonoBehaviour
{
    public float projectile_speed;
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
    }

    // Update is called once per frame
    void Update()
    {
        // check if it's time to fire and spawn a bullet if it is
        if (Time.time > no_firing)
        {
            for (int i = -30; i <= 30; i += 15)
            {
                CreateBullet(i);
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
