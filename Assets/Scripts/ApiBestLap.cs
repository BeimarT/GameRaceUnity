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
    // public List<double> resultados = new List<double>();

    // public double [] resultados = new double [4];
    public static string min;
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
                try{
                    JsonData jsondata = JsonMapper.ToObject(www.downloadHandler.text);
                    min = (string) jsondata [0]["time"];
                    min = min.Substring(0, 5);
                } catch (Exception e){
                    min = "0";
                    Debug.Log(e);
                }
                Debug.Log(min);
                // Debug.Log(jsondata.Count);   

                // for (int i = 0; i < jsondata.Count; i++)
                // {
                //     time = (string) jsondata [i]["time"];
                //     resultados.Add(double.Parse(time));
                //     Debug.Log("resultado" + resultados[i]);
                // }
                // min = resultados.Min();
                // Debug.Log("Este es el minimo" + resultados.Min());
            }
    }

}
