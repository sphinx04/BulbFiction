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
    private Light2D playerLight;
    private float currentIntensity;
    private float currentEnergy;


    void Start()
    {
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
            currentEnergy -= tmpInt * 0.05f;
            playerLight.intensity = (defaultIntensity + tmpInt) * currentEnergy / DefaultEnergy;
            PlayerControl();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FlipGravity();
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
            currentEnergy = DefaultEnergy;
        }
    }

    IEnumerator SpawnParticle()
    { 
        GameObject temp = Instantiate(PlayerParticles, transform.position, transform.rotation);
        yield return new WaitForSeconds(3);
        Destroy(temp);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            StartCoroutine(SpawnParticle());
            rb.velocity = Vector2.up * jumpForce * rb.gravityScale / Mathf.Abs(rb.gravityScale);
        }
    }

    public void FlipGravity()
    {
        if (isGrounded)
        {
            StartCoroutine(SpawnParticle());
            rb.velocity = Vector2.up * jumpForce * 0.5f * rb.gravityScale / Mathf.Abs(rb.gravityScale);
            rb.gravityScale = -rb.gravityScale;
        }
    }
}
