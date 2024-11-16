using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamePauseSys : MonoBehaviour
{
    [SerializeField]private Character character;
    [SerializeField]private GameObject augmentsScreen;
    public bool isPause = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (character.IsDead() || augmentsScreen.activeSelf)
        {
            isPause = true;
        }
        else
        {
            isPause = false;
        }
        GamePause();
    }
    void GamePause()
    {
       
        if (isPause)
        {
           
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
