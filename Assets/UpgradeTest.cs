using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTest : MonoBehaviour
{
    public Sprite newSprite;

    private SpriteRenderer spriteRenderer;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) 
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = newSprite;
        }
    }

   
    
}
