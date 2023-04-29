using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject electricSkill;

    public void getElectricitySkill()
    {
        audioSource.Play();
        Electricity ground = FindObjectOfType<Electricity>();
        ground.electricCheck = true;
        Debug.Log("전기 스킬 얻었다");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster"))
        {
            GameObject go = Instantiate(electricSkill, other.transform.position, electricSkill.transform.rotation);
            Destroy(go, 2.0f);
            Destroy(gameObject);
        }
    }
}
