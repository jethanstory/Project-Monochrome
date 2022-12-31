//Change scene event system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReplayGame()
    {
        SceneManager.LoadScene("MainZone"); //SceneManager.LoadScene("Forest");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("MainZone"); //SceneManager.LoadScene("Forest");
    }

    public void MainMenuScene() 
    {
        SceneManager.LoadScene("MainMenu"); //SceneManager.LoadScene("Forest");
    }
}
