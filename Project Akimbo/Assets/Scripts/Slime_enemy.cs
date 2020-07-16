using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_enemy : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    public float fire_rate;
    float no_firing;
    // Start is called before the first frame update
    void Start()
    {
        no_firing = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // check if it's time to fire and spawn a bullet if it is
        if (Time.time > no_firing)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            no_firing = Time.time + fire_rate;
        }
    }
}
