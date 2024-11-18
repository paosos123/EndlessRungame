using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Everythingmove
{
    [SerializeField]private int damages = 20;

  
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
       
        Move();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Damage(damages);
            Destroy(gameObject);
        }
        
    }
    public void Damage(float damagePoints)
    {
        if (character.health > 0)
            character.health -= damagePoints;
    }
}
