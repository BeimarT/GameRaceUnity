using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public float timer;
    public float x;
    public float y;
    // Update is called once per frame
    	public class PlayerData{
		public float positiony;
        public float positionx;
		public float timer;
        public int vueltas; 
        public float positionx2;
        public float positiony2;
        public float rotation;
        public float counterTimerResultant;
	}
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Quit()
    {
        PlayerData data = new PlayerData();
        data.timer = ContadorVueltas.timer;
        data.positionx = CarSteering_2ndplayer.posX;
        data.positiony = CarSteering_2ndplayer.posY;
        data.vueltas = ContadorVueltas.vuelta;
        data.rotation = CarSteering_2ndplayer.rotation;
        data.counterTimerResultant = ContadorVueltas.counterTimerResultant;
        Debug.Log(data.counterTimerResultant);
        SaveGame.Save<PlayerData>(LoginBBDD.username + SceneManager.GetActiveScene().name, data);
        SceneManager.LoadScene("MainMenu");
    }
}