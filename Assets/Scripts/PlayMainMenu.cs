using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayMainMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    public static int flag = 0;
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
    
    public void PlayGame_Selection1(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
        flag = 0;
    }
    public void PlayGame_Selection2(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
        flag = 1;
    }
    public void PlayGame_Selection3(){
        SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
        flag = 2;
    }
    public void PlayGame_Selection4(){
        SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
        flag = 3;
    }
    public void PlayGame_Selection5(){
        SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
        flag = 4;
    }
    public void PlayGame_Selection6(){
        SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
        flag = 5;
    }
        public void PlayGame_Selection7(){
        SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
        flag = 6;
    }
}
