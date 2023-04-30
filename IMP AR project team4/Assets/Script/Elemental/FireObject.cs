using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject fireSkill;
    public int damage;
    public void getFireSkill()
    {
        audioSource.Play();
        Fire fire = FindObjectOfType<Fire>();
        fire.fireCheck = true;
        Debug.Log("���̾� ��ų �����");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.CompareTag("RockMonster") || other.CompareTag("IceMonster") || other.CompareTag("FireMonster"))
        {
            GameObject go = Instantiate(fireSkill, other.transform.position, fireSkill.transform.rotation);
            Destroy(go, 4.0f);
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
            else if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }

        }
    }
}
