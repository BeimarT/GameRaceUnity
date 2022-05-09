using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayMainMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    public static int flag = 0;
    public int repeat = 0;
    public static int flag2 = 0;
    bool multiplayer = GameSelector.multiplayer;
    public void goToTutorial(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Escena_Tutorial");
    }
    public void MenuSelector(){
        SceneManager.LoadScene("MenuSelectorJuego");
    }
    public void MenuSelector_Ciudad(){
        SceneManager.LoadScene("MenuSelectorJuego_Ciudad");
    }
    public void goToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayGame_Monaco()
    {
        Debug.Log(ContadorVueltas.map);
        if (multiplayer == true){
            Time.timeScale = 1;
            if (ContadorVueltas.map == "Escena_Ciudad_DoublePlayer"){
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
                } else{
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
                }
        } else {
            if (ContadorVueltas.map == "Escena_Ciudad"){
                Time.timeScale = 1;
                SceneManager.LoadScene("Escena_ciudad");
            } else{
                Time.timeScale = 1;
                SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
            }
        }
    }
    public void PlayGame_Ciudad()
    {
        if (multiplayer){
            Time.timeScale = 1;
            SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
        } else {
            Time.timeScale = 1;
            SceneManager.LoadScene("Escena_Ciudad");
        }
    }
    public void PlayGame_Tutorial()
    {
            Time.timeScale = 1;
            SceneManager.LoadScene("Escena_Tutorial");
    }
    public void goToSelectorDeModo(){
        SceneManager.LoadScene("MenuModosDeJuego");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayGame_Selection1(){
            if (multiplayer == false){
                flag = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
            } else {
                Debug.Log("Entra Double");
                Debug.Log(multiplayer);
                if (repeat != 0){
                    flag2 = 0;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
                } else {
                    flag = 0;
                    repeat = 1;
                }
            }
        }
    public void PlayGame_Selection2(){
            if (multiplayer == false){
                flag = 1;
                Time.timeScale = 1;
                SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
            } else {
                if (repeat != 0){
                    flag2 = 1;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 1;
                }
            }
    }
    public void PlayGame_Selection3(){
            if (multiplayer == false){
                flag = 2;
                Time.timeScale = 1;
                SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
            } else {
                if (repeat != 0){
                    flag2 = 2;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 2;
                }
            }
    }
    public void PlayGame_Selection4(){
            if (multiplayer == false){
                flag = 3;
                Time.timeScale = 1;
                SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
            } else {
                if (repeat != 0){
                    flag2 = 3;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 3;
                }
            }
    }
    public void PlayGame_Selection5(){
            if (multiplayer == false){
                flag = 4;
                Time.timeScale = 1;
                SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
            } else {
                if (repeat != 0){
                    flag2 = 4;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 4;
                }
            }
    }
    public void PlayGame_Selection6(){
            if (multiplayer == false){
                flag = 5;
                Time.timeScale = 1;
                SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
            } else {
                if (repeat != 0){
                    flag2 = 5;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 5;
                }
            }
    }
        public void PlayGame_Selection7(){
            if (multiplayer == false){
                flag = 6;
                Time.timeScale = 1;
                SceneManager.LoadScene("Circuito1_Monaco_SinglePlayer");
            } else {
                if (repeat != 0){
                    flag2 = 6;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Circuito1_Monaco_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 6;
                }
            }
    }
        public void PlayGame_Selection1_Ciudad(){
            if (multiplayer == false){
                flag = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene("Escena_Ciudad");
            } else {
                Debug.Log("Entra Double");
                Debug.Log(multiplayer);
                if (repeat != 0){
                    flag2 = 0;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
                } else {
                    flag = 0;
                    repeat = 1;
                }
            }
        }
    public void PlayGame_Selection2_Ciudad(){
            if (multiplayer == false){
                flag = 1;
                Time.timeScale = 1;
                SceneManager.LoadScene("Escena_Ciudad");
            } else {
                if (repeat != 0){
                    flag2 = 1;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 1;
                }
            }
    }
    public void PlayGame_Selection3_Ciudad(){
            if (multiplayer == false){
                flag = 2;
                Time.timeScale = 1;
                SceneManager.LoadScene("Escena_Ciudad");
            } else {
                if (repeat != 0){
                    flag2 = 2;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 2;
                }
            }
    }
    public void PlayGame_Selection4_Ciudad(){
            if (multiplayer == false){
                flag = 3;
                Time.timeScale = 1;
                SceneManager.LoadScene("Escena_Ciudad");
            } else {
                if (repeat != 0){
                    flag2 = 3;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 3;
                }
            }
    }
    public void PlayGame_Selection5_Ciudad(){
            if (multiplayer == false){
                flag = 4;
                Time.timeScale = 1;
                SceneManager.LoadScene("Escena_Ciudad");
            } else {
                if (repeat != 0){
                    flag2 = 4;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 4;
                }
            }
    }
    public void PlayGame_Selection6_Ciudad(){
            if (multiplayer == false){
                flag = 5;
                Time.timeScale = 1;
                SceneManager.LoadScene("Escena_Ciudad");
            } else {
                if (repeat != 0){
                    flag2 = 5;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 5;
                }
            }
    }
        public void PlayGame_Selection7_Ciudad(){
            if (multiplayer == false){
                flag = 6;
                Time.timeScale = 1;
                SceneManager.LoadScene("Escena_Ciudad");
            } else {
                if (repeat != 0){
                    flag2 = 6;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Escena_Ciudad_DoublePlayer");
                } else {
                    repeat = 1;
                    flag = 6;
                }
            }
    }
    public void MapSelection(){
        SceneManager.LoadScene("MenuMapas");
    }
}
