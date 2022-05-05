using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;




public class TextSync : MonoBehaviour
{
    public Text textoACambiar;
    public List<float> timerGuardado = new List<float>();
    public string tiempoencontrado = "";
    float bestLap = 1000;

    // Start is called before the first frame update
    void Start()
    {

        // tiempoencontrado = GameObject.Find("ContadorContraVueltas").GetComponent<ContadorVueltas>().timerGuardado[0].ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        float tiempoencontrado = ContadorVueltas.timer;

        //Lista con todos los tiempos 
        List<float> totalTimes  = ContadorVueltas.timerGuardado;

        for(int i = 0; i < totalTimes.Count -1; i++) 
        {
            if(totalTimes[i] < bestLap){
                bestLap = totalTimes[i];
            }
        }        

        textoACambiar.text = bestLap.ToString();
    }
    //Peticion a la api con la var filtrada

    public void saveBestLapMongoDB()
    {
        StartCoroutine(BestLapSave());
    }
    IEnumerator BestLapSave()
    {
                Scene map = SceneManager.GetActiveScene();

        WWWForm form = new WWWForm();
        form.AddField("user", LoginBBDD.username);
        form.AddField("time", bestLap.ToString());
        form.AddField("map", map.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/timelap" , form);
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            } else {
                Debug.Log("Best lap saved succesfull");
            }
    }
}
