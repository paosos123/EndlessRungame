using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
   
    public Button myButton;
    private int i = 0;
    void UninterCon()
    {
        if (i == 0)
        {
            myButton.interactable = false; // ทำให้ปุ่มสามารถโต้ตอบได้
            i++;
        }
     
    }
    public void RunningScene()
    {
        SceneManager.LoadScene("RunningGroundTest");
    }

    void Start()
    {
          i = 0;
    }
    public void Restart()
    {
         var currentScene = SceneManager.GetActiveScene();
         SceneManager.LoadScene(currentScene.name);
    }
}
