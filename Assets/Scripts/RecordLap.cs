using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class RecordLap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void getBestLapMongoDB()
    {
        StartCoroutine(GetBestLap());
    }
    IEnumerator GetBestLap()
    {
        WWWForm form = new WWWForm();
    
        UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:8000/api/record");
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            } else {
                Debug.Log(www);
                Debug.Log("Getting best lap successfully");
            }
    }
}
