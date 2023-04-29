using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject fireSkill;
    public void getFireSkill()
    {
        audioSource.Play();
        Fire fire = FindObjectOfType<Fire>();
        fire.fireCheck = true;
        Debug.Log("파이어 스킬 얻었다");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster")) 
        {
            GameObject go = Instantiate(fireSkill, other.transform.position, fireSkill.transform.rotation);
            Destroy(go,4.0f);
            Destroy(gameObject);
        }
    }
}
