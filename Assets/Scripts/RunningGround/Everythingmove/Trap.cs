using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]private int damages = 20;

    [SerializeField] private Character character;
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
