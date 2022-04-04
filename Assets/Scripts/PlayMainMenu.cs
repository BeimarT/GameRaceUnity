using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayMainMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    public void PlayGame_Monaco_DoublePlayer()
    {
        SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
        Time.timeScale = 1;
    }
        
    public void PlayGame_Monaco_SinglePlayer()
    {
        SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
        Time.timeScale = 1;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void PlayGame1(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
