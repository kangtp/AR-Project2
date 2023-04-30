using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject waterSkill;
    private int damage;
    float waterTime;


    private void Start()
    {
        waterTime = Time.time;
    }
    private void Update()
    {
        if (gameObject.tag == "Untagged")
        {
            if (Time.time - waterTime > 3f)
            {
                Destroy(gameObject);
            }
        }
    }
    public void getWaterSkill()
    {
        audioSource.Play();
        Water water = FindObjectOfType<Water>();
        water.waterCheck = true;
        Debug.Log("물 스킬 얻었다");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster"))
        {
            GameObject go = Instantiate(waterSkill, other.transform.position, waterSkill.transform.rotation);
            Destroy(go, 3.0f);
            Destroy(gameObject);
            if (other.CompareTag("RockMonster"))
            {
                damage = 10;
                other.GetComponent<EarthMonster>().HPControl(damage);

            }
            else if (other.CompareTag("IceMonster"))
            {
                damage = 0;
                other.GetComponent<IceMonster>().HPControl(damage);

            }
            else if (other.CompareTag("FireMonster"))
            {
                damage = 30;
                other.GetComponent<FireMonster>().HPControl(damage);

            }
            else if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}