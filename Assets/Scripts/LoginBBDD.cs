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
        form.AddField("email", gmailField.text.TrimEnd('\u200b'));
        form.AddField("password", passwordField.text.TrimEnd('\u200b'));

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/user/login" , form);
        yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            } else {
                Debug.Log("Login" + www.downloadHandler.text);
            }
    }
}
