using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController audio;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

        if(audio == null){
            audio = this;
        } else {
            Destroy(gameObject);
        }
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
