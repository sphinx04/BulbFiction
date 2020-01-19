using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

    private Animator animator;
    public ParticleSystem particles;

    //public Animator animator;

    const float k_GroundedRadius = 0.1f; // Radius of the overlap circle to determine if grounded
    public bool m_Grounded;            // Whether or not the player is grounded.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;


    public float energy = 100f;
    public float energyCost = 1f;
    public float currEnergy;

    private void Awake()
    {
        currEnergy = energy;
        animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void Update()
    {
        if(currEnergy < 0)
        {
            gameObject.GetComponent<PlayerManager>().Death();
        }
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
        /*particles.transform.position = */

        //m_GroundCheck.transform.position = transform.position - new Vector3(0f, 0.5f, 0f);
    }


    public void Move(float move, bool jump)
    {
        var emission = particles.emission;

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
                
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            if (Mathf.Abs(move) > 0)
            {
                emission.enabled = true;
                animator.SetTrigger("Run");
                animator.ResetTrigger("Idle");
                animator.ResetTrigger("Jump");
                currEnergy -= energyCost * Time.deltaTime;
            }
            else
            {
                emission.enabled = false;
                animator.SetTrigger("Idle");
                animator.ResetTrigger("Run");
                animator.ResetTrigger("Jump");
            }
        }
        // If the player should jump...
        if (jump && m_Grounded)
        {
            // Add a vertical force to the player.
            Jump();
        }
        if (!m_Grounded)
        {
            emission.enabled = true;
            animator.SetTrigger("Jump");
            animator.ResetTrigger("Idle");
            animator.ResetTrigger("Run");
        }
    }

    public void Jump()
    {
        if (m_Grounded)
        {
            m_Grounded = false;
            //m_Rigidbody2D.AddRelativeForce(new Vector2(0f, m_JumpForce));
            m_Rigidbody2D.velocity = new Vector2(0, 20);
            currEnergy -= energyCost;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}