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

        //Lista con todos los tiempos 
        List<float> totalTimes  = ContadorVueltas.timerGuardado;

        float bestLap = 1000;
        for(int i = 0; i < totalTimes.Count -1; i++) 
        {
            if(totalTimes[i] < bestLap){
                bestLap = totalTimes[i];
            }
        }
        //Peticion a la api con la var filtrada
        

        textoACambiar.text = bestLap.ToString();
    }
}
