using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RegisterBBDD : MonoBehaviour
{
    public InputField usernameField;
    public InputField gmailField;
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;

    

    public void RegisterStart()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("email", gmailField.text);
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("rol", "user");
        form.AddField("surname", "Pruebas");
        form.AddField("detail", "Pruebas");
        form.AddField("otherInformation", "Pruebas");
        form.AddField("photo", "Pruebas");
        form.AddField("googleID", "Pruebas");

        using (UnityWebRequest www = UnityWebRequest.Post("https://apidefinitivalaravelbrumbrum.herokuapp.com/api/user" , form))
        {
            yield return www.SendWebRequest();
            Debug.Log(www.responseCode);
            Debug.Log(www.result);
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            } else
            {
                Debug.Log("Register succesfull");
            }
        }
    }
        public void VerifyInputs()
        {
            submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8);
        }
}
