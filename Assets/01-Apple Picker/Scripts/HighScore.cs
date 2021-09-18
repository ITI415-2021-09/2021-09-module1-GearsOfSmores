using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
      static public int highScore = 1000;

    private void Awake()
    {
        // If the PlayerPrevious HighScore already exists read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // Assign the high score to Highscore
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        // Assign the high score to Highscore
         PlayerPrefs.SetInt("HighScore", highScore);

    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score:"+ highScore;

        // Update the PlayerPrefs HighScore if necessary
        if (highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
