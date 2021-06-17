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
public class app42Manager : MonoBehaviour, App42CallBack
{
    object resp;
    public bool lead;
    ScoreBoardService scoreBoardService = null; // Initialising ScoreBoard Service.
    public void OnException(Exception ex)
    {
        print(ex);
    }

    public void OnSuccess(object response)
    {
        print(response);

    }
        // Start is called before the first frame update
        void Start()
    {
        App42API.Initialize("58fb660e91f2aec0289bafc9db25f8c5aa83355d6eda5674409ee538ac18f87d", "9c619f79546c69341523d8776091545bbda685bd443c0f5f7db37f2dd549ec71");
        App42API.SetOfflineStorage(true, 20);
        App42Log.SetDebug(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UploadScore(string nama,int score)
    {
        scoreBoardService = App42API.BuildScoreBoardService();
        scoreBoardService.SaveUserScore("Augmented Reality", nama, score, this);
        print("berhasil");
    }
}
