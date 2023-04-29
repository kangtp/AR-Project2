using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpd;
    float bulletTime;
    public int damage = 3;
    Text killCount;

    Player player;
    private int killcount;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        bulletTime = Time.time;
        killCount = GameObject.Find("KillCount").GetComponent<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - bulletTime > 3f)
        {
            Destroy(gameObject);
        }
        gameObject.transform.Rotate(rotateSpd * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RockMonster"))
        {
            Debug.Log("I hit RockMonster");
            other.GetComponent<EarthMonster>().HP -= damage;

            if (other.GetComponent<EarthMonster>().HP <= 0)
            {
                Destroy(other.gameObject);
                killcount++;
                killCount.GetComponent<KillCounter>().UpdateKillCount(player.kill);
            }
        }
        else if (other.CompareTag("IceMonster"))
        {
            Debug.Log("I hit IceMonster");
            other.GetComponent<IceMonster>().HP -= damage;

            if (other.GetComponent<IceMonster>().HP <= 0)
            {
                Destroy(other.gameObject);
                player.kill++;
                killCount.GetComponent<KillCounter>().UpdateKillCount(player.kill);
            }
        }
        else if (other.CompareTag("FireMonster"))
        {
            Debug.Log("I hit FireMonster");
            other.GetComponent<FireMonster>().HP -= damage;

            if (other.GetComponent<FireMonster>().HP <= 0)
            {
                Destroy(other.gameObject);
                player.kill++;
                killCount.GetComponent<KillCounter>().UpdateKillCount(player.kill);
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("I hit Enemy");
            Destroy(other.gameObject);
            player.kill++;
            killCount.GetComponent<KillCounter>().UpdateKillCount(player.kill);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("RockMonster") || other.CompareTag("FireMonster") || other.CompareTag("IceMonster"))
        {
            Destroy(gameObject);
        }
    }

}
