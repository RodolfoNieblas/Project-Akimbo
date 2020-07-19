using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_indicator : MonoBehaviour
{
    private BoxCollider2D box_col;
    SpriteRenderer spr_rend;

    void Awake()
    {
        spr_rend = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            spr_rend.color = new Color(1.0f, 0f, 0f, 1.0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            spr_rend.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
    }
}
