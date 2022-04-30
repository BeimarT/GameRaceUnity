using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoginBBDD : MonoBehaviour
{
    public InputField gmailField;
    public InputField passwordField;
    public InputField usernameField;

    public static string username;

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

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/login" , form);
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            } else {
                Debug.Log("Login succesfull");
                username = gmailField.text;
                SceneManager.LoadScene(3);
            }
    }
    public static bool LoggedIn {
        get {
            return username != null;
        }
    }
}
