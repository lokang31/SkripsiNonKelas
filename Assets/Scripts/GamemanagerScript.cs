using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamemanagerScript : MonoBehaviour
{
    float time;
    bool isPlayerAlive;
    public int Score;
    public Healthmanager playerHealth;
    public Text ScoreText;
    public GameObject gameOverPanel;
    public Text skor, waktu, skorTertinggi;
    int currHighScore;
    app42Manager app42Man;
    // Start is called before the first frame update
    void Start()
    {
      app42Man =  GetComponent<app42Manager>();
        isPlayerAlive = true;
        currHighScore = PlayerPrefs.GetInt("Highscore");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        ScoreText.text = Score.ToString();
      //  CheckPlayerAlive();
    }

    public bool CheckPlayerAlive()
    {
        if (playerHealth.currHealth <= 0)
        {
            isPlayerAlive = false;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            //save highscore
            if (Score > currHighScore)
            {
                currHighScore = Score;
                PlayerPrefs.SetInt("Highscore", currHighScore);
            }
           
            //show text
            skor.text = "Skor : " + Score;
            waktu.text = $"Waktu Bermain : {(int)time} Detik";
            skorTertinggi.text = "Skor Tertinggi : " + currHighScore;
            app42Man.UploadScore(PlayerPrefs.GetString("Nickname"), PlayerPrefs.GetInt("Highscore"));
        }
       
        
        return isPlayerAlive;
    }
}
