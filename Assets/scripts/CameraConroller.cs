using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    // //first way
    // [SerializeField] private Transform player;
    // private Vector3 pos;


    // private void Awake()
    // {
    //     if (!player)
    //     {
    //         player = FindObjectOfType<Hero>().transform;
    //     }
    // }

    // private void Update()
    // {
    //     pos = player.position;
    //     pos.z = -10f;
    //     pos.y = 1f;
    //     transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    // }
    //second way
    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float bottomLimit;
    [SerializeField]
    private float upperLimit;
    [SerializeField]
    private float leftLimit;
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isleft;
    private Transform player;
    private int lastx;

   void Start()
   {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isleft);
   }
    public void FindPlayer(bool playerIsleft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastx = Mathf.RoundToInt(player.position.x);
        if (playerIsleft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);     
        }
        else
        {
           transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z); 
        }
    }

    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastx) isleft = false; else if (currentX < lastx) isleft = true;
            lastx = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isleft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
            );
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, upperLimit));
    }

}
