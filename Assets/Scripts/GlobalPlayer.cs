using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayer : MonoBehaviour 
{
    public static GlobalPlayer Instance;

    public float Aceleracion;
    public float Desaceleracion;
    public float Tiempo;
    public float Giro;

    void Awake ()   
       {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }
    void Start(){
        Aceleracion = GlobalPlayer.Instance.Aceleracion;
        Desaceleracion = GlobalPlayer.Instance.Desaceleracion;
        Tiempo = GlobalPlayer.Instance.Tiempo;
        Giro = GlobalPlayer.Instance.Giro;
    }
      public void SavePlayer()
    {
        GlobalPlayer.Instance.Aceleracion = Aceleracion;
        GlobalPlayer.Instance.Desaceleracion = Desaceleracion;
        GlobalPlayer.Instance.Giro = Giro;
        GlobalPlayer.Instance.Tiempo = Tiempo;
        }
}