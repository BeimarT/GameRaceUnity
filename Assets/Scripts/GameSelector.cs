using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSelector : MonoBehaviour
{
    public static bool multiplayer = false;
    public static bool cargar;
    public static int partida = 1;
    // Start is called before the first frame update

        public void PlayGame_Monaco_DoublePlayer(){
            multiplayer = true;
            SceneManager.LoadScene("MenuMapas");
        }
        
        public void PlayGame_Monaco_SinglePlayer(){
            multiplayer = false;
            SceneManager.LoadScene("CargarPartida");
        }
        public void NuevaPartida(){
            cargar = true;
            SceneManager.LoadScene("CargarPartidaSeleccion");
        }
        public void partida1(){
            partida = 1;
            SceneManager.LoadScene("MenuMapas");
            Debug.Log("entra");
        }
        public void partida2(){
            partida = 2;
            SceneManager.LoadScene("MenuMapas");
            Debug.Log("entra");
        }
        public void NoNuevaPartida(){
            cargar = false;
            SceneManager.LoadScene("CargarPartidaSeleccion");
        }
    // Update is called once per frame
    void Update()
    {
    }
}
