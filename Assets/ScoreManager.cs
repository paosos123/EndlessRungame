using System.Collections;
using System.Collections.Generic;
using Dan.Demo;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score =0;
   
    public float incrementInterval = 1f; // Seconds between score increments
    public TMP_Text scoreText;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "RunningGroundTest")
        {
            score = 0;
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " +score.ToString();
        timer += Time.deltaTime;
        if (timer >= incrementInterval)
        {
            timer -= incrementInterval;
            score++;
            // Update UI or other game logic with the new score
           
        }
        LeaderboardShowcase._playerScore = score;
    }
}
