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
        Debug.Log("���̾� ��ų �����");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject go = Instantiate(fireSkill, other.transform.position, fireSkill.transform.rotation);
            Destroy(go,4.0f);
            Destroy(gameObject);
        }
    }
}
