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


    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int extraJumps;
    private Light2D playerLight;
    private float currentIntensity;
    private float currentEnergy;


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        playerLight = GetComponent<Light2D>();
        currentIntensity = defaultIntensity;
        playerLight.intensity = currentIntensity;
        currentEnergy = DefaultEnergy;
    }

    private void Update()
    {
        if (currentEnergy <= 0f)
        {
            Time.timeScale = 0;
        }
        else
        {
            float tmpInt = ChangeIntensity();
            currentEnergy -= tmpInt * 0.02f;
            playerLight.intensity = (defaultIntensity + tmpInt) * currentEnergy / DefaultEnergy;
            PlayerControl();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        

        if (moveInput > 0)
        {
            sr.flipX = true;
        }
        else if(moveInput < 0)
        {
            sr.flipX = false;
        }
    }

    public void OnOff()
    {
        gameObject.SetActive(gameObject.activeSelf ? false : true);
    }

    float ChangeIntensity()
    {
        return Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y) ?
Mathf.Abs(rb.velocity.x) * additionalIntensity * defaultIntensity :
Mathf.Abs(rb.velocity.y) * 0.5f * additionalIntensity * defaultIntensity;
    }

    void PlayerControl()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            Instantiate(PlayerParticles, transform.position, transform.rotation);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            Instantiate(PlayerParticles, transform.position - new Vector3(0f,0.0f,0f), transform.rotation);
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bulb")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Light2D>().enabled = false;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            //collision.gameObject.SetActive(false);
            currentEnergy = DefaultEnergy;
        }
    }
}
