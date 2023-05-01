using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject electricSkill;
    private int damage;
    float electricityTime;

    private void Start()
    {
        electricityTime = Time.time; //to check the start time
    }
    
    private void Update()
    {
        //if electricity object alive over 3s, destroy the electricity object
        if (gameObject.tag == "Untagged")
        {
            if (Time.time - electricityTime > 3.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    //If touch the electricity object, then play the get sound and set 'electricCheck' is true. 
    //if electricCheck becomes true, execute the ElectricShooting function in Electricity script.
    public void getElectricitySkill()
    {
        audioSource.Play();
        Electricity ground = FindObjectOfType<Electricity>();
        ground.electricCheck = true;
    }

    //electricity objejct collision with 3 Enemy(rock, ice, fire)
    private void OnTriggerEnter(Collider other)
    {
        //if electricity object collide with Boss Enemy, instantiate electricity skill effect.
        if (other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster"))
        {
            GameObject go = Instantiate(electricSkill, other.transform.position, electricSkill.transform.rotation);
            Destroy(go, 3.0f);
            Destroy(gameObject);

            //damage varies depending on the type of enemy.
            if (other.CompareTag("RockMonster"))
            {
                damage = 40;
                other.GetComponent<EarthMonster>().HPControl(damage);
            }
            else if (other.CompareTag("IceMonster"))
            {
                damage = 10;
                other.GetComponent<IceMonster>().HPControl(damage);
            }
            else if (other.CompareTag("FireMonster"))
            {
                damage = 20;
                other.GetComponent<FireMonster>().HPControl(damage);
            }
        }
    }
}