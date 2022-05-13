using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUsername : MonoBehaviour
{
    public Text playerDisplay;
    public Text bestTime;
    // Start is called before the first frame update
    private void Start()
    {
        if(LoginBBDD.LoggedIn)
        {
            playerDisplay.text = "Bienvenido: "+ LoginBBDD.username;
            bestTime.text = "Mejor vuelta: "+ ApiBestLap.min + " segundos";
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
