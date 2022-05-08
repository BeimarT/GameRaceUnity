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
    float bestLap = 12000;

    // Start is called before the first frame update
    void Start()
    {
        // float tiempoencontrado = ContadorVueltas.timer;
        //Lista con todos los tiempos 
        List<float> totalTimes  = ContadorVueltas.timerGuardado;

        for(int i = 0; i < totalTimes.Count; i++) 
        {
            if(totalTimes[i] < bestLap){
                Debug.Log(totalTimes[i]);
                bestLap = totalTimes[i];
            }
        }        
        textoACambiar.text = bestLap.ToString();
        saveBestLapMongoDB();
    }
    

    // Update is called once per frame
    // void Update()
    // {
    // }
    //Peticion a la api con la var filtrada

    public void saveBestLapMongoDB()
    {
        StartCoroutine(BestLapSave());
    }
    IEnumerator BestLapSave()
    {

        WWWForm form = new WWWForm();
        form.AddField("user", LoginBBDD.username);
        form.AddField("time", bestLap.ToString());
        form.AddField("map", ContadorVueltas.map.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/record" , form);
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            } else {
                Debug.Log("Best lap saved succesfull");
            }
    }
}
