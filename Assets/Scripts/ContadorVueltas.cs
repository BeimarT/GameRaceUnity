using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;
using BayatGames.SaveGameFree;

public class ContadorVueltas: MonoBehaviour
{
    	public class PlayerData{
		public float positiony;
        public float positionx;
		public float timer;
        public int vueltas; 
        public bool checkpoint1;
        public bool checkpoint2;
	}
    public static ContadorVueltas Instance;
    public static float timer = 0;
    private bool startTimer = true;
    public static int vuelta = 0;
    public static List<float> timerGuardado = new List<float>();
    public static bool checkpoint1 = false; //Cuando estén en true se podrá contar la vuelta
    public static bool checkpoint2 = false;
    public static string map;
    public string username = LoginBBDD.username;
    // private bool checkpoint3 = false;  
    // private bool checkpoint4 = false;  
    // private bool checkpoint5 = false;
    // private bool checkpoint6 = false;
    // private bool checkpoint7 = false;
    // private bool checkpoint8 = false;
    // private bool checkpoint9 = false;
    // private bool checkpoint10 = false;
    // private bool checkpoint11 = false;
    // private bool checkpoint12 = false;
    [SerializeField]
    public int NVueltas;
    [SerializeField]
    public float countertimer;

    public TextMeshProUGUI text;
    public Text Tiempo; //Texto para el tiempo
    public Text Vueltas; //"" "" "" vueltas
    private TextMeshProUGUI TMPtext;
    void Start()
    {
        if (GameSelector.multiplayer == true ){
                map = SceneManager.GetActiveScene().name;
                timer = 0;  //seteamos tiempo y vuelta en 0
                vuelta = 0;
                startTimer = true;
                checkpoint1 = false;
                checkpoint2 = false;
        } else {
            if (SaveGame.Exists(username + SceneManager.GetActiveScene().name)){
                map = SceneManager.GetActiveScene().name;
                timer = SaveGame.Load<PlayerData>(username + SceneManager.GetActiveScene().name).timer; 
                vuelta = SaveGame.Load<PlayerData>(username + SceneManager.GetActiveScene().name).vueltas;
                startTimer = true;
                checkpoint1 = SaveGame.Load<PlayerData>(username + SceneManager.GetActiveScene().name).checkpoint1;
                checkpoint2 = SaveGame.Load<PlayerData>(username + SceneManager.GetActiveScene().name).checkpoint2;
            } else {
                map = SceneManager.GetActiveScene().name;
                Debug.Log(map);
                timer = 0;  //seteamos tiempo y vuelta en 0
                vuelta = 0;
                startTimer = true;
                checkpoint1 = false;
                checkpoint2 = false;
            }
        }
    }

    void Update()
    {
        if (timer < countertimer){
            if (startTimer == true)
            {
                timer = timer + Time.deltaTime;
                Tiempo.text = "  " + Mathf.Round(timer * 100f) / 100f;
                Vueltas.text = "  " + vuelta + " / " + NVueltas;
            }
        } else {
            Time.timeScale = 0;
            SaveGame.Delete(username +  SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("MenuPerder");
        }
        }



    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "Start"){
            if (checkpoint1 == true && checkpoint2 == true){
                //  && checkpoint3 == true && checkpoint4 == true && checkpoint5 == true && checkpoint6 == true && checkpoint7 == true && checkpoint8 == true && checkpoint9 == true && checkpoint10 == true && checkpoint11 == true && checkpoint12 == true)
                if (vuelta + 1 == NVueltas){
                    if (SaveGame.Exists(username + SceneManager.GetActiveScene().name)){
                        Debug.Log("exists");
                        SaveGame.Delete(username + SceneManager.GetActiveScene().name);
                    }
                    timerGuardado.Add(timer);
                    SceneManager.LoadScene("MenuVictoria");
                    Time.timeScale = 0;
                    timer = 0;
                    vuelta = 0;
                    checkpoint1 = false; 
                    checkpoint2 = false;
                    } else {
                        timerGuardado.Add(timer);
                        vuelta += 1;
                        checkpoint1 = false;
                        checkpoint2 = false;
                        timer=0;
                    }
                    // checkpoint3 = false;
                    // checkpoint4 = false;
                    // checkpoint5 = false;
                    // checkpoint6 = false;
                    // checkpoint7 = false;
                    // checkpoint8 = false;
                    // checkpoint9 = false;
                    // checkpoint10 = false;
                    // checkpoint11 = false;
                    // checkpoint12 = false;
                }
            }

            if (other.gameObject.name == "CheckPoint1")
            {
                // Debug.Log("CheckPoint1");
                checkpoint1 = true;
            }

            if (other.gameObject.name == "CheckPoint2")
            {
                // Debug.Log("CheckPoint2");
                checkpoint2 = true;
            }
            // if (other.gameObject.name == "CheckPoint3")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint3 = true;
            // }
            // if (other.gameObject.name == "CheckPoint4")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint4 = true;
            // }
            // if (other.gameObject.name == "CheckPoint5")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint5 = true;
            // }
            // if (other.gameObject.name == "CheckPoint6")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint6 = true;
            // }
            // if (other.gameObject.name == "CheckPoint7")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint7 = true;
            // }
            // if (other.gameObject.name == "CheckPoint8")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint8 = true;
            // }
            // if (other.gameObject.name == "CheckPoint9")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint9 = true;
            // }
            // if (other.gameObject.name == "CheckPoint10")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint10 = true;
            // }
            // if (other.gameObject.name == "CheckPoint11")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint11 = true;
            // }            
            // if (other.gameObject.name == "CheckPoint12")
            // {
            //     Debug.Log("CheckPoint2");
            //     checkpoint12 = true;
            // }
    }
    }