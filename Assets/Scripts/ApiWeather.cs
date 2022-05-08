using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
public class ApiWeather : MonoBehaviour
{
    public class WeatherInfo{
        public string name;

    }

        void Start()
        {
            StartCoroutine(gettingWeather());
        }
        IEnumerator gettingWeather()
        {
            WWWForm form = new WWWForm();
        
            UnityWebRequest www = UnityWebRequest.Get("http://api.weatherstack.com/current?access_key=a5536361332efe8ea59b0bdef1e0af17&query=Barcelona");
            yield return www.SendWebRequest();
                if(www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);

                } else {
                    var text = www.downloadHandler.text;
                    WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(text);
                    Debug.Log(info);
                    Debug.Log(text);
                    Debug.Log("Getting weather successfully");
                }
        }
}
