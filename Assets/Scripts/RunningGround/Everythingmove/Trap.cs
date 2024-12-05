using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trap : Everythingmove
{
    [SerializeField]private int damages = 20;
     // Reference to the red panel Image component
    public float damageDuration = 1f; 
   
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
            soundEffePlayer.DamageSound();
            character.damagePanel.gameObject.SetActive(true);
            // Start a coroutine to deactivate the panel after 2 seconds
            StartCoroutine(FadeOutPanel());
            Destroy(gameObject);
           
        }
        if (other.gameObject.CompareTag("Dead"))
        { 
            Destroy(gameObject);
        }
    
    }
    public void Damage(float damagePoints)
    {
        if (character.health > 0)
            character.health -= damagePoints;
    }
    IEnumerator FadeOutPanel()
    {
        yield return new WaitForSeconds(damageDuration);
        character.damagePanel.gameObject.SetActive(false);
    }
}
