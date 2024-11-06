using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthfillingpot : MonoBehaviour
{
    [SerializeField]private int healingPoints = 20;
    [SerializeField]private Character character;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
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
