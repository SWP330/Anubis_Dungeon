using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Scene");
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Load_Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

