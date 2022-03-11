using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayMainMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    public void ContraReloj()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void MenuPerder()
    {
        SceneManager.LoadScene(6);
    }
    public void MenuVictoria()
    {
        SceneManager.LoadScene(7);
    }
    public void MenuLoginRegistro()
    {
        SceneManager.LoadScene(0);
    }
    public void Registro()
    {
        SceneManager.LoadScene(1);
    }
    public void LogIn()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
