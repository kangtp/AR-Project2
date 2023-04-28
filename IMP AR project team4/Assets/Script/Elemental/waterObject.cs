using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject waterSkill;

    public void getWaterSkill()
    {
        audioSource.Play();
        Water water = FindObjectOfType<Water>();
        water.waterCheck = true;
        Debug.Log("물 스킬 얻었다");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject go = Instantiate(waterSkill, other.transform.position, waterSkill.transform.rotation);
            //Destroy(go, 4.0f);
            Destroy(gameObject);
        }
    }
}
