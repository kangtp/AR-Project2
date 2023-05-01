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
        waterTime = Time.time;//to check the start time
    }
    private void Update()
    {
        //if water object alive over 3s, destroy the water object
        if (gameObject.tag == "Untagged")
        {
            if (Time.time - waterTime > 3.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    //If touch the water object, then play the get sound and set 'waterCheck' is true. 
    //if waterCheck becomes true, execute the WaterShooting function in Water script.
    public void getWaterSkill()
    {
        audioSource.Play();
        Water water = FindObjectOfType<Water>();
        water.waterCheck = true;
    }

    //water objejct collision with 3 Enemy(rock, ice, fire)
    private void OnTriggerEnter(Collider other)
    {
        //if water object collide with Boss Enemy, instantiate water skill effect.
        if (other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster"))
        {
            GameObject go = Instantiate(waterSkill, other.transform.position, waterSkill.transform.rotation);
            Destroy(go, 3.0f);
            Destroy(gameObject);

            //damage varies depending on the type of enemy.
            if (other.CompareTag("RockMonster"))
            {
                damage = 20;
                other.GetComponent<EarthMonster>().HPControl(damage);
            }
            else if (other.CompareTag("IceMonster"))
            {
                damage = 10;
                other.GetComponent<IceMonster>().HPControl(damage);
            }
            else if (other.CompareTag("FireMonster"))
            {
                damage = 40;
                other.GetComponent<FireMonster>().HPControl(damage);
            }
        }
    }
}