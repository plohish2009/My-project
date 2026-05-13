using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    Transform center;

    [SerializeField]
    private float radius = 2f;
    private float angularSpeed = 2f;
    private float positionX;
    private float positionY;
    private float angle = 0f;


    // Update is called once per frame
    void Update()
    {
        positionX = center.position.x + Mathf.Cos(angle) * radius;
        positionY = center.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2(positionX, positionY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
    
}
