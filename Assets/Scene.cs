using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
   
    public Button myButton;
     public  static  int revive= 0;
    public void UninterCon()
    {
        if (revive == 0)
        {
            myButton.interactable = false; // ทำให้ปุ่มสามารถโต้ตอบได้
            revive--;
        }
     
    }
    public void RunningScene()
    {
        SceneManager.LoadScene("RunningGroundTest");
    }

    void Start()
    {
        revive = 0;
    }
    public void Restart()
    {
         var currentScene = SceneManager.GetActiveScene();
         SceneManager.LoadScene(currentScene.name);
    }
}
