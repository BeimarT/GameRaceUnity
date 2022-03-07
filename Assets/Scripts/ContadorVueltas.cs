using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ContadorVueltas: MonoBehaviour
{
    public static ContadorVueltas Instance;
    public static float timer = 0;
    private bool startTimer = true;
    public float Vuelta = 0;
    public List<float> timerGuardado = new List<float>();
    private bool checkpoint1 = false; //Cuando estén en true se podrá contar la vuelta
    private bool checkpoint2 = false;

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
        timer = 0;  //seteamos tiempo y vuelta en 0
        Vuelta = 0;
        
    }

    void Update()
    {
        if (timer < countertimer){
            if (startTimer == true)
            {
                timer = timer + Time.deltaTime;
                Tiempo.text = "  " + timer;
                Vueltas.text = "  " + Vuelta + " / " + NVueltas;
            }
        } else {
            Time.timeScale = 0;
            SceneManager.LoadScene("MenuPerder");
        }
        if (Vuelta == NVueltas){
            Vuelta = timer;
            timerGuardado.Add(timer);
            // GlobalPlayer.Instance.SavePlayer();
            // Debug.Log(GlobalPlayer.Instance.Tiempo);
            Time.timeScale = 0;
            SceneManager.LoadScene("MenuVictoria");
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.name == "Start"){
                if (checkpoint1 == true && checkpoint2 == true)
                {
                    startTimer = false;
                    if (timer < Vuelta)
                    {
                        Vuelta = timer;

                    }

                    timerGuardado.Add(timer);
                    // GlobalPlayer.Instance.Tiempo = timer;
                    startTimer = true;
                    
                    Vuelta += 1;
                    checkpoint1 = false;
                    checkpoint2 = false;



                }
            }

            if (other.gameObject.name == "CheckPoint1")
            {
                Debug.Log("CheckPoint1");
                checkpoint1 = true;
            }

            if (other.gameObject.name == "CheckPoint2")
            {
                Debug.Log("CheckPoint2");
                checkpoint2 = true;
            }
        }
    public void SavePlayer(){

    }
}
