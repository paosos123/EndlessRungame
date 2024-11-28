using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Healthfillingpot : Everythingmove
{
    
  public static int HealthfillingpotIncrese = 0;
  private int healingPoints = 20+ HealthfillingpotIncrese;
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
            Heal(healingPoints);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
    }
    void Heal(float healingPoints)
    {
           character.health += healingPoints;  
    }
    
}
