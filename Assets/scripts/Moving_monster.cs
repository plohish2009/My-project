using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moving_monster : MonoBehaviour
{
    [SerializeField]
    Transform right;

    [SerializeField]
    Transform left;
    private float speed = 3f;
    private Rigidbody2D rb;
    private Transform currentpoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentpoint = right.transform;
    }
    private void Update()
    {
        Vector3 temp = transform.localScale;
        if (currentpoint == right)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == left)
        {
            temp.x *= -1;
            transform.localScale = temp;
            currentpoint = right;
        }
        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == right)
        {
            temp.x *= -1;
            transform.localScale = temp;
            currentpoint = left;
        }
    }
}
