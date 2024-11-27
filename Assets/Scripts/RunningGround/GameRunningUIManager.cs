using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunningUIManager : MonoBehaviour
{
    [SerializeField]private Character character;
    [SerializeField]private GameObject gameOverScreen;
    void Update()
    {
        if (character.IsDead())
        {
            gameOverScreen.SetActive(true);
        }
        else  if(!character.IsDead())
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("DemoScene");
        
    }
    
}
