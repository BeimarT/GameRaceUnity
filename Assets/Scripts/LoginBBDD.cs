using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class LoginBBDD : MonoBehaviour
{
    public InputField gmailField;
    public InputField passwordField;

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

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/user/login" , form);
        yield return www.SendWebRequest();
    }
}
