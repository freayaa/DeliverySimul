using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backtomenu : MonoBehaviour
{
    public void MainMenuButton()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //AudioListener.pause = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
