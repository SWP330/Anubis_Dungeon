using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;


public class mainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingPanel;

    public TMP_Text menuText;


    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void sMenu()
    {
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void mMenu()
    {
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void myVolume(float sliderVolume)
    {
        //myMixer.SetFloat
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
