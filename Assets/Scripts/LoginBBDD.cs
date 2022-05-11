using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using LitJson;


public class LoginBBDD : MonoBehaviour
{
    public InputField gmailField;
    public InputField passwordField;
    public InputField usernameField;
    public static int id;

    public static string username;
    public Text incorrectCredentials;
    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(Login());
    }
    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", gmailField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("https://apidefinitivalaravelbrumbrum.herokuapp.com/api/login" , form);
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                incorrectCredentials.text = "Credenciales incorrectas";

            } else {
                Debug.Log("Login succesfull");
                Debug.Log(www.downloadHandler.text);
                JsonData jsondata = JsonMapper.ToObject(www.downloadHandler.text);
                id = (int) jsondata["User"];
                username = (string) jsondata["body"]["username"];
                SceneManager.LoadScene("MainMenu");
            }
    }
    public static bool LoggedIn {
        get {
            return username != "null";
        }
    }
}
