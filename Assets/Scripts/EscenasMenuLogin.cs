using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasMenuLogin : MonoBehaviour { 
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
}

