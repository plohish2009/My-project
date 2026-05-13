using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource bookSound;

    [SerializeField] private float speed = 3f;// speed
    //[SerializeField] private int lives = 5;
    public float fastspeed = 7f;
    public float realspeed;
    [SerializeField] private float jumpForce = 0.1f;// force of jumpforce
    public bool isGrounded = false;
    private float horizontalmove = 0f;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public Animator anim;



    private void Start()
    {

        gameObject.transform.position = new Vector3(Hero_death.teleport_cords[Hero_death.tracker],Hero_death.teleport_cords[Hero_death.tracker + 1], 0);

        
        gameObject.transform.position = new Vector3(Hero_death.teleport_cords[Hero_death.tracker],Hero_death.teleport_cords[Hero_death.tracker + 1], 0);
        //gameObject.transform.position = new Vector3(3, 3, 0);

    }
    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       sprite = GetComponentInChildren<SpriteRenderer>();
       anim = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        CheckGround();
    }


    private void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * speed;
        if (Mathf.Abs(horizontalmove) > 0.01)
        {
            Run();

        }
        anim.SetFloat("movex", Mathf.Abs(horizontalmove));
        if (isGrounded && Input.GetButton("Jump"))
        {
            Jump();
            
        }
        if (isGrounded == false)
        {
            anim.SetBool("jumping", true);
        }
        else
        {
            anim.SetBool("jumping", false);
        }
    }


    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("run", true);
            realspeed = fastspeed;
        }
        else
        {
            anim.SetBool("run", false);
            realspeed = speed;
        }
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, realspeed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        jumpSound.Play();
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Platform")
    //     {
    //        this.gameObject.transform.parent = collision.transform;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Platform")
    //     {

    //         this.gameObject.transform.parent = null;
    //     }
    // }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("book"))
        {
            
        }
        bookSound.Play();
    }

}
