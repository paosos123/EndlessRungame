using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Augments :  Everythingmove
{
    private bool hitPlayer= false;
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
            hitPlayer = true;
        }
    }

    void ShowUISelectAugment(bool hit)
    {
        if (hit)
        {
            
        }
    }
   
}
