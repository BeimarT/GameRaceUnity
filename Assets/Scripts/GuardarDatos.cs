using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GuardarDatos : MonoBehaviour
{
    public float timer = ContadorVueltas.timer;
    public int vuelta = 0;
    public int Nvuelta = 0;
    public float ejeX = 0;
    public float ejeY = 0;
    public string user = LoginBBDD.username;
    Scene map = SceneManager.GetActiveScene();


    public void saveDataUser()
    {
        StartCoroutine(saveData());
    }
    IEnumerator saveData()
    {
        WWWForm form = new WWWForm();
        form.AddField("timer", LoginBBDD.username);
        form.AddField("vuelta", vuelta);
        form.AddField("nVuelta","" );
        form.AddField("ejeX", "");
        form.AddField("ejeY", "");
        form.AddField("user", user );
        form.AddField("map", map.ToString() );

        UnityWebRequest www = UnityWebRequest.Post("URL API" , form);
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            } else {
                Debug.Log("User data saved succesfull");
            }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
