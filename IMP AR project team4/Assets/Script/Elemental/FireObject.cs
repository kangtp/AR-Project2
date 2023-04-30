using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject fireSkill;
    public int damage;
    float fireTime;
    public void getFireSkill()
    {
        audioSource.Play();
        Fire fire = FindObjectOfType<Fire>();
        fire.fireCheck = true;
        Debug.Log("파이어 스킬 얻었다");
    }
    private void Start()
    {
        fireTime = Time.time;
    }
    private void Update()
    {
        if(gameObject.tag=="Untagged")
        {
            if(Time.time - fireTime>3f)
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster"))
        {
            GameObject go = Instantiate(fireSkill, other.transform.position, fireSkill.transform.rotation);
            Destroy(go, 3f);

            Destroy(gameObject);
            if (other.CompareTag("RockMonster"))
            {
                damage = 10;
                other.GetComponent<EarthMonster>().HPControl(damage);

            }
            else if (other.CompareTag("IceMonster"))
            {
                damage = 30;
                other.GetComponent<IceMonster>().HPControl(damage);

            }
            else if (other.CompareTag("FireMonster"))
            {
                damage = 0;
                other.GetComponent<FireMonster>().HPControl(damage);

            }
        }
    }
}
