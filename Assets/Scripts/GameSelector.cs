using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSelector : MonoBehaviour
{
    public static bool multiplayer = false;
    // Start is called before the first frame update

        public void PlayGame_Monaco_DoublePlayer(){
            SceneManager.LoadScene("MenuSelectorJuego");
            multiplayer = true;
        }
        
        public void PlayGame_Monaco_SinglePlayer(){
            SceneManager.LoadScene("MenuSelectorJuego");
            multiplayer = false;
        }

    // Update is called once per frame
    void Update()
    {
    }
}
