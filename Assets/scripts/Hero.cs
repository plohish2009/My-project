using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource bookSound;


    [SerializeField] private float speed = 3f;
    public float fastspeed = 7f;
    public float realspeed;
    [SerializeField] private float jumpForce = 0.1f; // УВЕЛИЧЬТЕ силу прыжка! 0.1f слишком мало
    public bool isGrounded;
    private float horizontalmove = 0f;

    Transform grounded;
    public LayerMask layerMask;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public Animator anim;

    private void Start()
    {
        gameObject.transform.position = new Vector3(Hero_death.teleport_cords[Hero_death.tracker], Hero_death.teleport_cords[Hero_death.tracker + 1], 0);
        gameObject.transform.position = new Vector3(Hero_death.teleport_cords[Hero_death.tracker], Hero_death.teleport_cords[Hero_death.tracker + 1], 0);
        grounded = GameObject.Find(this.name + "/grounded").transform;
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        
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

        // Управление анимацией бега
        anim.SetFloat("movex", Mathf.Abs(horizontalmove));

        isGrounded = Physics2D.Linecast(transform.position, grounded.position, layerMask);

        anim.SetBool("jump", !isGrounded);

        // Прыжок
        if (isGrounded && Input.GetButtonDown("Jump")) // Используйте GetButtonDown, а не GetButton
        {
            anim.SetBool("jump", true);
            Jump();
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


        rb.velocity = new Vector2(rb.velocity.x, 0); // Сброс вертикальной скорости для более четкого прыжка
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        jumpSound.Play();
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.6f);
        bool wasGrounded = isGrounded;
        isGrounded = collider.Length > 1;

        // Если приземлились, сбрасываем флаг прыжка прямо здесь
        anim.SetBool("onGround", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Vector3 worldPosition = transform.position;
            this.gameObject.transform.parent = collision.transform;
            transform.position = worldPosition;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Vector3 worldPosition = transform.position;
            this.gameObject.transform.parent = null;
            transform.position = worldPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("book"))
        {
            bookSound.Play();
        }
    }
}