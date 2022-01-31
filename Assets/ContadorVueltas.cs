using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorVueltas: MonoBehaviour
{
    public float timer = 0;
    private bool startTimer = false;
    public float Vuelta = 0;

    private bool checkpoint1 = false;
    private bool checkpoint2 = false;

    public Text Tiempo;
    public Text Vueltas;
    void Start()
    {
        timer = 0;
        Vuelta = 0;
    }

    void Update()
    {

        if (startTimer == true)
        {
            timer = timer + Time.deltaTime;

            Tiempo.text = "  " + timer;
            Vueltas.text = "  " + Vuelta;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Start")
        {

            if (checkpoint1 == true && checkpoint2 == true)
            {
                startTimer = false;

                if (Vuelta == 0)
                {
                    Vuelta = timer;
                }


                if (timer < Vuelta)
                {
                    Vuelta = timer;

                }
                startTimer = true;
                timer = 0;
                Vuelta += 1;
                checkpoint1 = false;
                checkpoint2 = false;



            }
        }

        if (other.gameObject.name == "CheckPoint1")
        {
            Debug.Log("CheckPoint1");
            checkpoint1 = true;
        }

        if (other.gameObject.name == "CheckPoint2")
        {
            Debug.Log("CheckPoint2");
            checkpoint2 = true;
        }
    }
}
