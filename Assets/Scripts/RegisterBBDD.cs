using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RegisterBBDD : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;
    public Button submitButton;

    

    public void Start()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", "Bei");
        form.AddField("email", "Beimar@gmail.com");
        form.AddField("name", "Beimar");
        form.AddField("surname", "Torrez");
        form.AddField("rol", "User");
        form.AddField("password", "1234567");
        form.AddField("detail", "nada");
        form.AddField("otherInformation", "pruebas");

        using(UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/user" , form))
        { 
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            } else {
                Debug.Log("Register" + www.downloadHandler.text);
            }
        }
    }

        public void VerifyInputs()
        {
            submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8);
        }
}
