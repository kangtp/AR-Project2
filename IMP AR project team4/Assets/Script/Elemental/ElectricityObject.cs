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
        electricityTime = Time.time;
    }
    public void getElectricitySkill()
    {
        audioSource.Play();
        Electricity ground = FindObjectOfType<Electricity>();
        ground.electricCheck = true;
        Debug.Log("전기 스킬 얻었다");
    }
    private void Update()
    {
        if (gameObject.tag == "Untagged")
        {
            if (Time.time - electricityTime > 3f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster"))
        {
            GameObject go = Instantiate(electricSkill, other.transform.position, electricSkill.transform.rotation);
            Destroy(go, 3.0f);
            Destroy(gameObject);
            if (other.CompareTag("RockMonster"))
            {
                damage = 30;
                other.GetComponent<EarthMonster>().HPControl(damage);

            }
            else if (other.CompareTag("IceMonster"))
            {
                damage = 0;
                other.GetComponent<IceMonster>().HPControl(damage);

            }
            else if (other.CompareTag("FireMonster"))
            {
                damage = 10;
                other.GetComponent<FireMonster>().HPControl(damage);

            }
            else if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}