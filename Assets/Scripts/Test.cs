using UnityEngine;
using System;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using UnityEngine.UI;
public class Test : MonoBehaviour, App42CallBack
{
    object resp;
    public bool lead;
    ScoreBoardService scoreBoardService = null; // Initialising ScoreBoard Service.
   
    public List<String> userName;
    public List<int> userScore;
    public Text nameText;
    public Text scoreText;
    public GameObject prefabsNama,panelNama;
    public int count;
    public void OnException(Exception ex)
    {
        print(ex);
    }

    public void OnSuccess(object response)
    {
        print(response);
        if(lead == true)
        {
            lead = false;
            
            Game gameResponseObj = (Game)response;
            IList<Game.Score> topRankersList = gameResponseObj.GetScoreList();
            if (topRankersList.Count > 0)
            {



                for (int i = 0; i < gameResponseObj.GetScoreList().Count; i++)
                {
                    string scorerName = gameResponseObj.GetScoreList()[i].GetUserName();
                    double scorerValue = gameResponseObj.GetScoreList()[i].GetValue();

                    userName.Add(scorerName);
                    userScore.Add((int)scorerValue);
                }
            }
            scoreText.text = userScore[0].ToString();
            nameText.text = userName[0];
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        App42API.Initialize("58fb660e91f2aec0289bafc9db25f8c5aa83355d6eda5674409ee538ac18f87d", "9c619f79546c69341523d8776091545bbda685bd443c0f5f7db37f2dd549ec71");
        App42API.SetOfflineStorage(true, 20);
        App42Log.SetDebug(true);
        lead = false;
        count = 0;
        Invoke("LoadLeaderboard", 1f);
        Invoke("ShowLeaderboard", 2f);
    }

    // Update is called once per frame
    void Update()
    {
      
        
       
      
       
    }
    public void LoadLeaderboard()
    {
        scoreBoardService = App42API.BuildScoreBoardService();
        int max = 5;
        scoreBoardService.GetTopNRankers("Augmented Reality", max, this);
        lead = true;
    }
    public void ShowLeaderboard()
    {

        if (userName.Count > 0)
        {

            do
            {
                print("usercount" + userName.Count);
                if (count < userName.Count)
                {
                    GameObject skorNama = Instantiate(prefabsNama, panelNama.transform.position, Quaternion.identity);
                    skorNama.transform.SetParent(panelNama.transform);
                    skorNama.transform.localScale = new Vector3(1, 1, 1);
                    skorNama.transform.GetChild(0).GetComponent<Text>().text = (count + 1).ToString();
                    skorNama.transform.GetChild(1).GetComponent<Text>().text = userName[count];
                    skorNama.transform.GetChild(2).GetComponent<Text>().text = userScore[count].ToString();
                    count++;
                }
                else
                {
                    break;
                }
            }
            while (count < userName.Count);


        }
    }
}
