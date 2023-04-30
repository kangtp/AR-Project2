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
    private Scene targetScene;
    public Text killText;

    public Image bloodScreen;



    void Start()
    {
        lifeManger = GameObject.FindObjectOfType<LifeManager>();
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

                if (targetScene != null)
                {
                    SceneManager.LoadScene("GameOver");
                }


            }
        }

    }

    //if player damaged, show Blood effect
    IEnumerator ShowBloodScreen()
    {
        bloodScreen.color = new Color(1, 0, 0, 0.3f);
        yield return new WaitForSeconds(0.3f);
        bloodScreen.color = Color.clear;
    }
}
/// player code
