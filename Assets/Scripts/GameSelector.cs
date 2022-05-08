using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSelector : MonoBehaviour
{
    public static bool multiplayer = false;
    // Start is called before the first frame update

        public void PlayGame_Monaco_DoublePlayer(){
            multiplayer = true;
            SceneManager.LoadScene("MenuMapas");
        }
        
        public void PlayGame_Monaco_SinglePlayer(){
            multiplayer = false;
            SceneManager.LoadScene("MenuMapas");
        }

    // Update is called once per frame
    void Update()
    {
    }
}
