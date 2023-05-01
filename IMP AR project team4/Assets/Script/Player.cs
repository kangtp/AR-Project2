using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public AudioSource hurtAudio;
    private int health = 5;     //player's health
    private LifeManager lifeManger;
    private Scene targetScene;
    public Image bloodScreen;   //if player get damage, show bloodScreen.

    void Start()
    {
        lifeManger = GameObject.FindObjectOfType<LifeManager>();
        targetScene = SceneManager.GetSceneByName("GameOver");  //get GameOver scene
    }

    private void OnTriggerEnter(Collider other)
    {
        //when player collide with Meteor(Boss attack)
        if (other.gameObject.CompareTag("Meteor"))
        {
            health--;
            lifeManger.reloadLife(health);
            Destroy(other.gameObject);
            hurtAudio.Play();
            StartCoroutine(ShowBloodScreen());

            //if player's health becomes 0, game over
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