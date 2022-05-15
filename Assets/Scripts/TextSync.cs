using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;


public class TextSync : MonoBehaviour
{
    public Text textoACambiar;
    public List<float> timerGuardado = new List<float>();
    public string tiempoencontrado = "";
    public static double bestLap = 1200.2000;

    public class Vuelta {
        public int user{get; set;}
        public double time{get; set;}
        public string map {get; set;}
    }
    // Start is called before the first frame update
    void Start()
    {
        // float tiempoencontrado = ContadorVueltas.timer;
        //Lista con todos los tiempos 
        List<float> totalTimes  = ContadorVueltas.timerGuardado;

        for(int i = 0; i < totalTimes.Count; i++) 
        {
            if(totalTimes[i] < bestLap){
                bestLap = totalTimes[i];
            }
        }
        textoACambiar.text = bestLap.ToString();
        GetVuelta();
        // saveBestLapMongoDB();
    }
    public static async Task<Vuelta> GetVuelta()
    {
        string url = "https://apribrumbrummongo.herokuapp.com/api/timelap";
        Vuelta vuelta = new Vuelta()
        {
            user = LoginBBDD.id,
            time = TextSync.bestLap,
            map = ContadorVueltas.map
        };

        HttpClient client = new HttpClient();

        var data = JsonConvert.SerializeObject(vuelta);

        HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            Debug.Log("Best lap saved");
            Debug.Log("Intento de http" + response);
        }

        return vuelta;
        Debug.Log(vuelta);
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
        Debug.Log(ContadorVueltas.map);
        form.AddField("user", LoginBBDD.id.ToString());
        form.AddField("time", bestLap.ToString());
        form.AddField("map", ContadorVueltas.map.ToString());

        UnityWebRequest www = UnityWebRequest.Post("https://apribrumbrummongo.herokuapp.com/api/timelap" , form);
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            } else {
                Debug.Log("Best lap saved succesfull");
            }
    }
}
