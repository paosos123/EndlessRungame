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

    private int doubleJump;

    //Health
    [SerializeField] private float damagePerSecond = 10f;
    [SerializeField] private Image healthBar;
    public float health, maxHealth = 100;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead())
        {
            Jump();
            Slide();
            TakeDamageEverySecond();
        }
        HealthGreatermoreOrLessthanMaxHealth();
        HealthBarFiller();
       
    }

    //Input Action
    void Jump()
    {

        if (playerInput.actions["Jump"].triggered && doubleJump > 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            doubleJump -= 1;
        }
        if (groundCheck)
        {
            doubleJump = 1;
        }
    }

    void Slide()
    {
        if (playerInput.actions["Slide"].IsPressed())
        {
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
