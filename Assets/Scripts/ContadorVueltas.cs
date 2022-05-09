using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
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
    public static string map;
    public string username = LoginBBDD.username;
    private bool checkpoint1 = false; //Cuando estén en true se podrá contar la vuelta
    private bool checkpoint2 = false;
    private bool checkpoint3 = false;  
    private bool checkpoint4 = false;  
    private bool checkpoint5 = false;
    private bool checkpoint6 = false;
    private bool checkpoint7 = false;
    private bool checkpoint8 = false;
    // private bool checkpoint9 = false;
    // private bool checkpoint10 = false;
    // private bool checkpoint11 = false;
    // private bool checkpoint12 = false;
    float counterTimerResultant;
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
        counterTimerResultant = countertimer;
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

                counterTimerResultant = counterTimerResultant - Time.deltaTime;
                Tiempo.text = "  " + counterTimerResultant;
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
            if (checkpoint1 == true && checkpoint2 == true  && checkpoint3 == true && checkpoint4 == true && checkpoint5 == true && checkpoint6 == true && checkpoint7 == true && checkpoint8){
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
                        checkpoint3 = false;
                        checkpoint4 = false;
                        checkpoint5 = false;
                        checkpoint6 = false;
                        checkpoint7 = false;
                        checkpoint8 = false;
                        timer=0;
                    }
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
            if (other.gameObject.name == "CheckPoint3")
            {
                Debug.Log("CheckPoint3");
                checkpoint3 = true;
            }
            if (other.gameObject.name == "CheckPoint4")
            {
                Debug.Log("CheckPoint4");
                checkpoint4 = true;
            }
            if (other.gameObject.name == "CheckPoint5")
            {
                Debug.Log("CheckPoint5");
                checkpoint5 = true;
            }
            if (other.gameObject.name == "CheckPoint6")
            {
                Debug.Log("CheckPoint6");
                checkpoint6 = true;
            }
            if (other.gameObject.name == "CheckPoint7")
            {
                Debug.Log("CheckPoint7");
                checkpoint7 = true;
            }
            if (other.gameObject.name == "CheckPoint8")
            {
                Debug.Log("CheckPoint8");
                checkpoint8 = true;
                callLogs();
            }
    }

    public void callLogs ()
    {
        StartCoroutine(apiLogs());
    }
    IEnumerator apiLogs()
    {
        WWWForm form = new WWWForm();
        form.AddField("checkPoint1", checkpoint1.ToString());
        form.AddField("checkPoint2", checkpoint2.ToString());
        form.AddField("checkPoint3", checkpoint3.ToString());
        form.AddField("checkPoint4", checkpoint4.ToString());
        form.AddField("checkPoint5", checkpoint5.ToString());
        form.AddField("checkPoint6", checkpoint6.ToString());
        form.AddField("checkPoint7", checkpoint7.ToString());
        form.AddField("checkPoint8", checkpoint8.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/logs" , form);
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            } else {
                Debug.Log("Checkpoints succesfull");
                Debug.Log(www.downloadHandler.text);

            }
    }
        
}
