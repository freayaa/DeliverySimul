using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //exiting the game
    public void Quit()
    {
        Application.Quit();
    }
    // start game
    public void StartGame()
    {
        SceneManager.LoadScene("_GamePlayScene");
    }
}
