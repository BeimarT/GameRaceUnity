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
    public static List<float> timerGuardado = new List<float>();
    private bool checkpoint1 = false; //Cuando estén en true se podrá contar la vuelta
    private bool checkpoint2 = false;
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
    string Nombre;
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
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene es " + scene.name);
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
                //  && checkpoint3 == true && checkpoint4 == true && checkpoint5 == true && checkpoint6 == true && checkpoint7 == true && checkpoint8 == true && checkpoint9 == true && checkpoint10 == true && checkpoint11 == true && checkpoint12 == true)
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
                    timer=0;
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
    public void SavePlayer(){

    }
}
