using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeSys : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
       if (Input.touchCount > 0)
       {
           Touch t = Input.GetTouch(0);

           Vector2 touchpos = Camera.main.ScreenToWorldPoint(t.position);

           // Check if the touch position overlaps the target GameObject's collider
           if (Physics2D.OverlapPoint(touchpos) == rock.GetComponent<Collider2D>())
           {
               Debug.Log("You touched the rock!");
               Character.upgradeHealth = 10;
           }
           else
           {
               // Optional: Handle touches on other GameObjects (if desired)
           }
       }
       /* if (Input.touchCount > 0)
      {
          Touch t = Input.GetTouch(0);

          Vector2 touchpos = Camera.main.ScreenToWorldPoint(t.position);

          // Use Physics2D.OverlapPoint to check for any collider at the touch position
          Collider2D collider = Physics2D.OverlapPoint(touchpos);

          if (collider != null)
          {
              // Check if the touched GameObject has the specific name "First"
              if (collider.gameObject.name == "First")
              {
                  // If the name is "First", log a specific message
                  Debug.Log("You touched the GameObject named 'First'");
              }
              else
              {
                  // Otherwise, log a generic message with the collider's name
                  Debug.Log("Touched GameObject: " + collider.gameObject.name);
              }
          }
      }*/
    }
    

    
}
