using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioSource hurtAudio;
    private int health = 5;

    //for Camera Shake
    //public float shakeTime = 1.0f;
    //public float shakeSpeed = 2.0f;
    //public float shakeAmount = 1.0f;
    //private Transform cam;
    public Image bloodScreen;
    void Start()
    {
        //cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Debug.Log("You die!");
            health = 10;
            //Death UI ¶ç¿ì±â
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            hurtAudio.Play();
            health--;
            StartCoroutine(ShowBloodScreen());
        }
        
    }

    //IEnumerator Shake()
    //{
    //    Vector3 originPos = cam.localPosition;
    //    float elapsedTime = 0.0f;

    //    while (elapsedTime < shakeTime)
    //    {
    //        Vector3 randomPoint = originPos + Random.insideUnitSphere * shakeAmount;
    //        cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);
    //        yield return null;
    //        elapsedTime += Time.deltaTime;
    //    }

    //    cam.position = originPos;
    //}

    //if player damaged, show Blood effect
    IEnumerator ShowBloodScreen()
    {
        bloodScreen.color = new Color(1, 0, 0, 0.3f);
        yield return new WaitForSeconds(0.3f);
        bloodScreen.color = Color.clear;
    }
}
