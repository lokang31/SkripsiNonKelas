using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public InputField inputFieldNick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveNick()
    {
        print(inputFieldNick.text);
        PlayerPrefs.SetString("Nick", inputFieldNick.text);
    }
}
