using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Scene");
    }

    public void Home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start_Menu");
    }
}
