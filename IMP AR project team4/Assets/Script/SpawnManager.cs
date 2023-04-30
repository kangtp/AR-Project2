using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject BasicMonster;
    public GameObject BossMonster;

    public Transform Player;

    public float spawnHeight;

    public float minRadius;
    public float maxRadius;

    public int NumofBasicMonster = 10;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.position = Player.position;
        StartCoroutine("SpawnBasic");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.childCount < 1)
        {
            SpawnBoss();
        }
    }


    private Vector3 GetRandomPositionOnCircle(float radius)
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0; // y축을 0으로 고정하여 원형 형태로 생성

        float r = Random.Range(minRadius, radius);
        return (randomDirection * r) + Player.position;
    }


    IEnumerator SpawnBasic()
    {
        for(int i = 0; i < NumofBasicMonster; i++)
        {
            Vector3 spawnPosition = GetRandomPositionOnCircle(maxRadius);
            spawnPosition.y = spawnHeight; // 높이 조정
            Debug.Log(spawnPosition);
            GameObject go = Instantiate(BasicMonster, spawnPosition, Quaternion.identity);
            go.transform.parent = this.transform;
            //SpawnIceObject[randomValue].transform.parent = this.transform;
            yield return new WaitForSeconds(1.0f);
        }
        StopCoroutine("SpawnBasic");
    }

     void SpawnBoss()
    {
        GameObject go = Instantiate(BossMonster, new Vector3(Player.position.x,Player.position.y,Player.position.z + 2.0f), Quaternion.identity);
        go.transform.parent = this.transform;
    }
}
