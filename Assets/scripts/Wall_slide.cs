using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_slide : MonoBehaviour
{
    public float distance = 2f;
    Hero player;

    public float speed_slide = 2f;

    void Start()
    {
        player = GetComponent<Hero>();
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * 2f, distance);

        if (player.isGrounded && hit.collider != null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed_slide);
        }

    }

}
