using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sr;
    public float DefaultEnergy = 100;
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpsValue;
    [Range(0f, 2f)]
    public float defaultIntensity;
    [Range(0f, 1f)]
    public float additionalIntensity;
    public GameObject PlayerParticles;
    public Joystick joystick;


    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Light2D playerLight;
    private float currentIntensity;
    [HideInInspector]
    public float currentEnergy;
    private float tmpInt;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLight = GetComponent<Light2D>();
        currentIntensity = defaultIntensity;
        playerLight.intensity = currentIntensity;
        currentEnergy = DefaultEnergy;
    }

    void Update()
    {
        moveInput = joystick.Horizontal * .75f;
        //moveInput = Input.GetAxis("Horizontal");
        rb.position = new Vector2(transform.position.x + moveInput * speed * 0.04f, transform.position.y);
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        tmpInt = ChangeIntensity();
        currentEnergy -= tmpInt * 0.04f;
        playerLight.intensity = (defaultIntensity + tmpInt) * currentEnergy / DefaultEnergy;
        PlayerControl();
    }

    //private void FixedUpdate()
    //{
    //    rb.position = new Vector2(transform.position.x + moveInput * speed * Time.deltaTime, transform.position.y);
    //}

    float ChangeIntensity()
    {
        return Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y) ?
Mathf.Abs(rb.velocity.x) * additionalIntensity * defaultIntensity :
Mathf.Abs(rb.velocity.y) * 0.5f * additionalIntensity * defaultIntensity;
    }

    void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FlipGravity();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            GameObject particle = Instantiate(PlayerParticles, transform.position, transform.rotation);
            rb.velocity = Vector2.up * jumpForce * rb.gravityScale / Mathf.Abs(rb.gravityScale);
            Destroy(particle, 2f);
        }
    }

    public void FlipGravity()
    {
        if (isGrounded)
        {
            GameObject particle = Instantiate(PlayerParticles, transform.position, transform.rotation);
            rb.velocity = Vector2.up * jumpForce * 0.5f * rb.gravityScale / Mathf.Abs(rb.gravityScale);
            rb.gravityScale = -rb.gravityScale;
            Destroy(particle, 2f);
        }
    }
}
