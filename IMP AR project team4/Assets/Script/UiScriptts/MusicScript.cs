using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
     //reference to audio source component
     public AudioSource myMusic;
     //public Slider Volume;

    //music volume variable that will be modified by slider
    //private float musicVolume =1f;

    // Start is called before the first frame update
    /* void Start()
    {
        //assign audio source comp to control it
        audioSrc = GetComponent<AudioSource>();
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (myMusic != null)
        {
            //setting volume option of audio source to be equal to music volume
            myMusic.volume = 1.0f;
        }
    }

}
