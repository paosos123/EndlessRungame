using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamePauseSys : MonoBehaviour
{
    [SerializeField]private Character character;
    [SerializeField]private GameObject augmentsScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GamePause();
    }
    void GamePause()
    {
        if (character.IsDead()||augmentsScreen.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
