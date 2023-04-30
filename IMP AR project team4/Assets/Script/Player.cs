using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public AudioSource hurtAudio;
    private int health = 5;
    private LifeManager lifeManger;
    public int kill = 0;
    private Scene targetScene;
   

    //for Camera Shake
    //public float shakeTime = 1.0f;
    //public float shakeSpeed = 2.0f;
    //public float shakeAmount = 1.0f;
    //private Transform cam;
    public Image bloodScreen;

   
  
    void Start()
    {
     
        lifeManger = GameObject.FindObjectOfType<LifeManager>();
        //cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //if (targetScene != null)
        //{
        //    parentUis = targetScene.GetRootGameObjects();

        //    for(int i = 0; i<parentUis.Length;i++)
        //    {
        //        Transform[] children = parentUis[i].GetComponentsInChildren<Transform>(true);
        //        for (int j = 0; j < children.Length; j++)
        //        {
        //            if (children[j].name == "GameOverMenu")
        //            {
        //                gameOverUI = children[j].gameObject;
        //                break;
        //            }
        //        }
        //    }
        //}
        targetScene = SceneManager.GetSceneByName("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
                health--;
                lifeManger.reloadLife(health);
                Destroy(other.gameObject);

                hurtAudio.Play();

                StartCoroutine(ShowBloodScreen());
            if (health <= 0)
            {

                //if (targetScene != null)
                //{
                //    SceneManager.LoadScene("GameOver");
                //}


            }
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