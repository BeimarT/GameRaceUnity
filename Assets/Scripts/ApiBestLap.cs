using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;


public class ApiBestLap : MonoBehaviour
{

    public static string time;
    public List<double> resultados = new List<double>();

    // public double [] resultados = new double [4];
    public static double min;
    public void Start ()
    {
        StartCoroutine(apiBestLap());
    }
    IEnumerator apiBestLap()
    {
        WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Get($"https://apribrumbrummongo.herokuapp.com/api/timelap/{LoginBBDD.id}");
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            } else {
                Debug.Log("Getting best lap succesfull");
                Debug.Log(www.downloadHandler.text);
                JsonData jsondata = JsonMapper.ToObject(www.downloadHandler.text);
                Debug.Log(jsondata.Count);   

                for (int i = 0; i < jsondata.Count; i++)
                {
                    time = (string) jsondata [i]["time"];
                    // resultados[i] = double.Parse(time);
                    resultados.Add(double.Parse(time));
                    Debug.Log("resultado" + resultados[i]);
                }
                min = resultados.Min();
                Debug.Log("Este es el minimo" + resultados.Min());
            }
    }
}
