using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpd; // cunai rotate speed
    float bulletTime; //to destroy bullet 
    public int damage = 3; // damage 
    public AudioClip audioClip; // audio
    public AudioClip audioClip2;// audio
    private AudioSource audioSource;

    Player player;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();// to get component in gameobject
        player = GameObject.Find("Player").GetComponent<Player>();// to get component at other gameobject
        bulletTime = Time.time;// to delete bullet 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - bulletTime > 3f)//time.time - bullettime > 3f -> after 3 sec late , bullet will destroy
        {
            Destroy(gameObject);
        }
        gameObject.transform.Rotate(rotateSpd * Time.deltaTime, 0, 0);// it is rotate at cunai
    }
    private void OnTriggerEnter(Collider other) // cunai trigger at that monster and when boss Monster die, load scene to clear scene
    {
        if (other.CompareTag("RockMonster")) // rock monster
        {
            Debug.Log("I hit RockMonster");
            other.GetComponent<EarthMonster>().HPControl(damage); // rockMonster_HpBar down 

            if (other.GetComponent<EarthMonster>().getHp() <= 0) // if hp<0 monster die
            {
                Destroy(other.gameObject);
                StartCoroutine("Clear_"); 
            }
        }
        else if (other.CompareTag("IceMonster")) // ice monster
        {
            Debug.Log("I hit IceMonster");
            other.GetComponent<IceMonster>().HPControl(damage); // iceMonster _HpBar down

            if (other.GetComponent<IceMonster>().getHp() <= 0) // if hp<0 monster die
            {
                Destroy(other.gameObject);
                StartCoroutine("Clear_");
            }
        }
        else if (other.CompareTag("FireMonster")) //Fire Monster
        {
            Debug.Log("I hit FireMonster");
            other.GetComponent<FireMonster>().HPControl(damage); // FireMonster Hp bar down 

            if (other.GetComponent<FireMonster>().getHp() <= 0) // if hp<0 monster die
            {
                Destroy(other.gameObject);
                StartCoroutine("Clear_"); 

            }
        }
        else if (other.CompareTag("Enemy"))// it is normal monster they are one kill by cunai
        {
            Debug.Log("I hit Enemy");
            audioSource.clip = audioClip; // it is death sound 
            audioSource.Play();
            other.GetComponentInParent<SpawnManager>().NumofBasicMonster -= 1; // when normal monster die, normal count -1 
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other) // if cunai triger at that tags then cunai destroy
    {
        if (other.CompareTag("Enemy") || other.CompareTag("RockMonster") || other.CompareTag("FireMonster") || other.CompareTag("IceMonster"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Clear_()//clear sound becuase we want to listen sound by using courutine
    {
        audioSource.clip = audioClip2;
        audioSource.Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Clear");

    }
}