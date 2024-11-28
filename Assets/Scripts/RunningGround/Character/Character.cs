using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //Input Action
    private SoundEffePlayer _soundEffePlayer;
    public Animator animator;
    public BoxCollider2D  boxCollider2D;
    [Header("Input Action")] 
    private InputAction jumpActions;
    private PlayerInput playerInput;
    private CharacterController controller;
    private Rigidbody2D rb;
    private bool groundCheck;
    public float jumpForce = 10f;
    [SerializeField] private float maxHoldTime = 1f;
    private float holdTime = 0f;
    [SerializeField] private int jumpCount = 0;
    private int maxJumpCount = 2;
    [Header("Health")]
    //Health
     private float damagePerSecond = 1f;
    
    [SerializeField] private Image healthBar;
    public  static int upgradeHealth = 0;
    public float health, maxHealth = 100   ;
    [Header("GamePause")]
    // Start is called before the first frame update
    [SerializeField] private gamePauseSys gamePauseSys;
    //Gravity
    [Header("Gravity")]
    [SerializeField] private float baseGravity = 2;
    [SerializeField] private float maxFallSpeed = 18f;
    [SerializeField] private float fallSpeedMultiplier = 2f;
    


    void Start()
    {
        maxHealth = 100 + upgradeHealth;
        Debug.Log(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        health = maxHealth;
        jumpActions = playerInput.actions["Jump"];

    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePauseSys.isPause)
        {
            Jump();
            Slide();
           
            TakeDamageEverySecond();
        }
        Gravity();
        HealthGreatermoreOrLessthanMaxHealth();
        HealthBarFiller();
        if (groundCheck ==false)
        {
            animator.SetBool("IsJump",true);
        }
        else
        {
            animator.SetBool("IsJump",false);
        }
    }
    
    
    //Input Action
    //public  void Jump()
    public  void Jump()
    {
        if (jumpActions.phase == InputActionPhase.Started && jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            holdTime = 0f;
              
        }
        if (jumpActions.phase == InputActionPhase.Performed&& jumpCount > 0)
        {
           
            holdTime += Time.deltaTime;
        }
        if (jumpActions.phase == InputActionPhase.Canceled&& jumpCount > 0)
        {
            float adjustedJumpForce = jumpForce * Mathf.Clamp01(holdTime / maxHoldTime);
            rb.velocity = new Vector2(rb.velocity.x, adjustedJumpForce);
            holdTime = 0f;
            
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJump",false);
    }
    void Slide()
    {
        if (playerInput.actions["Slide"].IsPressed())
        {
            animator.SetBool("IsSider",true);
            if (!groundCheck)
            {
                rb.AddForce(Vector2.down * 4, ForceMode2D.Impulse);
            }
            else if (groundCheck)
            {
                boxCollider2D.size = new Vector2(0.7015362f, 0.6549721f); // Example: Change the size
                boxCollider2D.offset = new Vector2(-0.004214764f, -0.4511586f);
            }
        }
        else if (!playerInput.actions["Slide"].IsPressed())
        {
            animator.SetBool("IsSider",false);
            boxCollider2D.size = new Vector2(0.7015362f, 1.481634f); // Example: Change the size
            boxCollider2D.offset = new Vector2(-0.004214764f, -0.03782761f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundCheck = true;
            jumpCount = 0;
        }
        
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundCheck = false;
        }
    }


    //Health
    void HealthGreatermoreOrLessthanMaxHealth()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }
    }

    void TakeDamageEverySecond()
    {
        health -= damagePerSecond * Time.deltaTime;
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    void Gravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;//Fallfaster
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    public void JumpingCount()
    {
        jumpCount++;
     
    }
    public bool IsDead()
    {
        return health <= 0;
    }

    
}
