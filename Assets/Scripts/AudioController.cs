using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioController : MonoBehaviour
{
    private static AudioController audio;

    // Start is called before the first frame update
    void Start()
     {
         //if we don't have an [_instance] set yet
         if(!audio){
             audio = this ;
         }
         //otherwise, if we do, kill this thing
         else{
            Destroy(this.gameObject) ;
         }

 
 
         DontDestroyOnLoad(this.gameObject) ;
     }
     void Update () {
                 if (SceneManager.GetActiveScene().name.Equals("Escena_Login") | SceneManager.GetActiveScene().name.Equals("Escena_Register")| SceneManager.GetActiveScene().name.Equals("Escena_MenuLoginRegistro"))
            {
                Destroy(this.gameObject) ;

            }
     }
}
