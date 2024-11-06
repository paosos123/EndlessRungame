using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Healthfillingpot : Everythingmove
{
    [SerializeField]private int healingPoints = 20;
   
    // Start is called before the first frame update
    void Start()
    {
       
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
            Heal(healingPoints);
            Destroy(gameObject);
        }
    }
    void Heal(float healingPoints)
    {
           character.health += healingPoints;  
    }
    
}
