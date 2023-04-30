using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpd;
    float bulletTime;
    public int damage = 3;
    public AudioClip audioClip;
    private AudioSource audioSource;

    Player player;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<Player>();
        bulletTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - bulletTime > 3f)
        {
            Destroy(gameObject);
        }
        gameObject.transform.Rotate(rotateSpd * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RockMonster"))
        {
            Debug.Log("I hit RockMonster");
            other.GetComponent<EarthMonster>().HPControl(damage);

            if (other.GetComponent<EarthMonster>().getHp() <= 0)
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene("Clear");
            }
        }
        else if (other.CompareTag("IceMonster"))
        {
            Debug.Log("I hit IceMonster");
            other.GetComponent<IceMonster>().HPControl(damage);

            if (other.GetComponent<IceMonster>().getHp() <= 0)
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene("Clear");

            }
        }
        else if (other.CompareTag("FireMonster"))
        {
            Debug.Log("I hit FireMonster");
            other.GetComponent<FireMonster>().HPControl(damage);

            if (other.GetComponent<FireMonster>().getHp() <= 0)
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene("Clear");

            }
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("I hit Enemy");
            audioSource.clip = audioClip;
            audioSource.Play();
            other.GetComponentInParent<SpawnManager>().NumofBasicMonster -= 1;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("RockMonster") || other.CompareTag("FireMonster") || other.CompareTag("IceMonster"))
        {
            Destroy(gameObject);
        }
    }

}