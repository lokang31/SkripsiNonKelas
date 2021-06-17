using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nicknamePanel,warningPanel;
    public InputField inputFieldNick;
    void Start()
    {
        print(PlayerPrefs.GetString("Nickname"));
     //  PlayerPrefs.SetString("Nickname", "");
        if (PlayerPrefs.GetString("Nickname") == "")
        {
            nicknamePanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveNick()
    {
        if(inputFieldNick.text != "")
        {
            print(inputFieldNick.text);
            PlayerPrefs.SetString("Nickname", inputFieldNick.text);
            nicknamePanel.SetActive(false);
        }
        else
        {
            print("Tidak boleh kosong");
            warningPanel.SetActive(true);
        }
    }
    public void closeWaring()
    {
        warningPanel.SetActive(false);
    }

}
