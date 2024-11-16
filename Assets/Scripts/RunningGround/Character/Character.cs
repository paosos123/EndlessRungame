using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //Input Action
    private PlayerInput playerInput;
    private CharacterController controller;
    private Rigidbody2D rb;
    private bool groundCheck;
    public float jumpForce = 10f;

   [SerializeField] private int jumpCount = 0;
    private int maxJumpCount = 2;

    //Health
    [SerializeField] private float damagePerSecond = 10f;
    [SerializeField] private Image healthBar;
    public float health, maxHealth = 100;
    
    // Start is called before the first frame update
    [SerializeField] private gamePauseSys gamePauseSys;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePauseSys.isPause)
        {
            Slide();
            //TakeDamageEverySecond();
        }
        HealthGreatermoreOrLessthanMaxHealth();
        HealthBarFiller();
       
    }

    
    //Input Action
    public  void Jump(InputAction.CallbackContext context)
    {
        
        /*if (playerInput.actions["Jump"].IsPressed() && jumpCount < maxJumpCount)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (playerInput.actions["Jump"].triggered)
        {
            jumpCount++;
        }*/
       if(context.performed && jumpCount < maxJumpCount &&!gamePauseSys.isPause)
       {
           rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
           jumpCount++;
       }
    }

    void Slide()
    {
        if (playerInput.actions["Slide"].IsPressed())
        {
            Debug.Log("Silder");
            if (!groundCheck)
            {
                rb.AddForce(Vector2.down * 4, ForceMode2D.Impulse);
            }
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

    public bool IsDead()
    {
        return health <= 0;
    }

    
}
