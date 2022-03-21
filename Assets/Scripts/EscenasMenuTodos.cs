using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasMenuTodos : MonoBehaviour { 
    public void GoToRegisterLogin()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToRegister ()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLogin ()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu ()
    {
        SceneManager.LoadScene(3);
    }
    public void ModosDeJuego()
    {
        SceneManager.LoadScene(4);
    }
    public void CircuitoMonaco()
    {
        SceneManager.LoadScene(5);
    }
    public void MenuPerder()
    {
        SceneManager.LoadScene(6);
    }
    public void MenuGanar()
    {
        SceneManager.LoadScene(7);
    }
}

