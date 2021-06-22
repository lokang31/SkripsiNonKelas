using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pausePanel;
    bool isLoading;
    public GameObject mainMenuPanel,loadingPanel;
    public Text loadingText,randomText;
    public string[] randomString;
    AsyncOperation asyncOperation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void LoadSceneAsync(string sceneName)
    {

        if(mainMenuPanel!=null) mainMenuPanel.SetActive(false);
        if (loadingPanel != null) loadingPanel.SetActive(true);
        randomText.text = randomString[Random.Range(0, randomString.Length)].ToString();
        loadingText.text = "Memuat...";
      
            isLoading = true;
             asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            asyncOperation.allowSceneActivation = false;

        StartCoroutine(Loaded());
       
        //while (!asyncOperation.isDone)
        //{
        //    if (asyncOperation.progress >= 0.9f)
        //    {
        //        loadingText.text = "Sentuh layar untuk melanjutkan";
        //            if (Input.GetMouseButtonDown(0))
        //        {
        //            asyncOperation.allowSceneActivation = true;
        //        }
        //    }
        //}


    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    IEnumerator Loaded()
    {
        yield return new WaitForSeconds(3f);
        asyncOperation.allowSceneActivation = true;

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
