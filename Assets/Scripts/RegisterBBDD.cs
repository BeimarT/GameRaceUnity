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
    public InputField rolField;
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
        form.AddField("rol", rolField.text);
        form.AddField("surname", "Prueba");
        form.AddField("detail", "nada");
        form.AddField("otherInformation", "pruebas");

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/user" , form);
            yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            } else
            {
                Debug.Log("Register" + www.downloadHandler.text);
            }
    
    }
        public void VerifyInputs()
        {
            submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8);
        }
}