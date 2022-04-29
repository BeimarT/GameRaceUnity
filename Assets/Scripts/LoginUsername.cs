using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUsername : MonoBehaviour
{
    public Text playerDisplay;
    // Start is called before the first frame update
    private void Start()
    {
        if(LoginBBDD.LoggedIn)
        {
            playerDisplay.text = LoginBBDD.username;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
