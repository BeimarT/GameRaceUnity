using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;




public class TextSync : MonoBehaviour
{
    public Text textoACambiar;
    public List<float> timerGuardado = new List<float>();
    public string tiempoencontrado = "";
    // Start is called before the first frame update
    void Start()
    {
        // tiempoencontrado = GameObject.Find("ContadorContraVueltas").GetComponent<ContadorVueltas>().timerGuardado[0].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float tiempoencontrado = ContadorVueltas.timer;
        // Debug.Log(GlobalPlayer.Instance.Tiempo);
        // tiempoencontrado = GlobalPlayer.Instance.Tiempo.ToString();

        textoACambiar.text = tiempoencontrado.ToString();
    }
}
