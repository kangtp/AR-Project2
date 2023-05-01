using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject fireSkill;
    public int damage;
    float fireTime;

    private void Start()
    {
        fireTime = Time.time; //to check the start time
    }
    private void Update()
    {
        //if fire object alive over 3s, destroy the fire object
        if(gameObject.tag=="Untagged")
        {
            if(Time.time - fireTime > 3.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    //If touch the fire object, then play the get sound and set 'fireCheck' is true. 
    //if fireCheck becomes true, execute the FireShooting function in Fire script.
    public void getFireSkill()
    {
        audioSource.Play();
        Fire fire = FindObjectOfType<Fire>();
        fire.fireCheck = true;
    }

    //fire objejct collision with 3 Enemy(rock, ice, fire)
    private void OnTriggerEnter(Collider other)
    {
        //if fire object collide with Boss Enemy, instantiate fire skill effect.
        if (other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster"))
        {
            GameObject go = Instantiate(fireSkill, other.transform.position, fireSkill.transform.rotation);
            Destroy(go, 3f);
            Destroy(gameObject);

            //damage varies depending on the type of enemy.
            if (other.CompareTag("RockMonster"))
            {
                damage = 20;
                other.GetComponent<EarthMonster>().HPControl(damage);
            }
            else if (other.CompareTag("IceMonster"))
            {
                damage = 40;
                other.GetComponent<IceMonster>().HPControl(damage);
            }
            else if (other.CompareTag("FireMonster"))
            {
                damage = 10;
                other.GetComponent<FireMonster>().HPControl(damage);
            }
        }
    }
}
