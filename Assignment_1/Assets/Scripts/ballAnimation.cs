using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballAnimation : MonoBehaviour
{
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Scene");
    }
}
