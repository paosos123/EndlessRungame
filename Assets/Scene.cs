using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
   
    
    public void RunningScene()
    {
        SceneManager.LoadScene("RunningGroundTest");
    }

    public void Restart()
    {
         var currentScene = SceneManager.GetActiveScene();
         SceneManager.LoadScene(currentScene.name);
    }
}
