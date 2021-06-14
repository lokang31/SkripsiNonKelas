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
    
    // Start is called before the first frame update
    void Start()
    {
        isPlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        ScoreText.text = Score.ToString();
        CheckPlayerAlive();
    }

    bool CheckPlayerAlive()
    {
        if (playerHealth.currHealth <= 0)
        {
            isPlayerAlive = false;
        }
       
        
        return isPlayerAlive;
    }
}
