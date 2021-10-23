using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator myAnimator;
    public float speed;
    public float jumpForce;
    private float moveInput;


    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    public bool Dash;
    public float Dash_T;
    public float Speed_Dash;

    public Transform FirePoint;
    public GameObject Bullet;
    public bool shooting;
    private float shoot_time;
    public float time;
    float nextFire = 0;
    float VelocidadDisparo = 0.30f;


    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
    }


    private void Update()
    {   //Jumping
        if (isGrounded == true) {
            extraJumps = extraJumpValue;
            myAnimator.SetBool("Sky", false);
        }
        else
        {
            myAnimator.SetBool("Sky", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }

        // Movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0) { 
            myAnimator.SetBool("isRunning", false);
        }
        else {
            myAnimator.SetBool("isRunning", true);
        }
        if (moveInput > 0 ) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //Disparo

        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFire && !Dash) {
            shoot_time = 0.01f;
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            nextFire = Time.time + VelocidadDisparo;
            if (!shooting){
                shooting = true;
            }
        }
        if (shooting) {
            shoot_time += 1 * Time.deltaTime;
            myAnimator.SetLayerWeight(1, 1);
        }
        else{
            myAnimator.SetLayerWeight(1, 0);
        }
        if (shoot_time >= time) {
            shooting = false;
            shoot_time = 0;
        }
    }
    void Dash_Skill()
    {
        if (Input.GetKey(KeyCode.X) && isGrounded == true) {
            Dash_T += 1 * Time.deltaTime;

            if (Dash_T < 0.35)
            {
                Dash = true;
                myAnimator.SetBool("Dash", true);
                transform.Translate(Vector3.right * Speed_Dash * Time.fixedDeltaTime);
            }
            else {
                Dash = false;
                myAnimator.SetBool("Dash", false);
            }
        }
        else {
            Dash = false;
            myAnimator.SetBool("Dash", false);
            Dash_T = 0;
        }
        
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        Dash_Skill();
    }
}
