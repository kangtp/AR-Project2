using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject BasicMonster;
    public GameObject BossMonster;

    public Transform SpawnArea;

    public Transform Player;

    public float spawnHeight;

    public float minRadius;
    public float maxRadius;

    public int NumofBasicMonster = 5;

    public GameObject warningMessage;

    private bool Stop = false;

    private int CycleMon;

    Fire fire;
    Water water;
    Electricity electricity;

    private void Awake()
    {
        fire = FindObjectOfType<Fire>();
        water = FindObjectOfType<Water>();
        electricity = FindAnyObjectByType<Electricity>();
    }
    void Start()
    {
       

        Stop = true;
        CycleMon = NumofBasicMonster;
        spawnHeight = 2f;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.position = Player.position;
        StartCoroutine("SpawnBasic");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.childCount < 1 && NumofBasicMonster < 1 && Stop )
        {
            warningMessage.SetActive(true);
            if(fire.fireCheck == true && water.waterCheck == true && electricity.electricCheck == true)
            {
                warningMessage.SetActive(false);
                SpawnBoss();
                Stop = false;
            }
        }
    }


    private Vector3 GetRandomPositionOnCircle(float radius)
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0; // y축을 0으로 고정하여 원형 형태로 생성

        float r = Random.Range(minRadius, radius);
        return (randomDirection * r) + SpawnArea.position;
        /*
        float randomAngle = Random.Range(-(Mathf.PI)/2, (Mathf.PI)/2); // 무작위 각도 선택
        Vector3 randomDirection = new Vector3(Mathf.Sin(randomAngle), 0, Mathf.Cos(randomAngle)); // 무작위 방향 벡터 생성
        float r = Random.Range(minRadius, radius); // 반지름 내에서 무작위 반지름 선택
        Vector3 randomPosition = (randomDirection * r) + Player.position; // 위치 계산
        return randomPosition;
        */
    }


    IEnumerator SpawnBasic()
    {
        for(int i = 0; i < CycleMon; i++)
        {
            Vector3 spawnPosition = GetRandomPositionOnCircle(maxRadius);
            spawnPosition.y = spawnHeight; // 높이 조정
            Debug.Log(spawnPosition);
            GameObject go = Instantiate(BasicMonster, spawnPosition, Quaternion.identity);
            go.transform.parent = this.transform;
            //SpawnIceObject[randomValue].transform.parent = this.transform;
            yield return new WaitForSeconds(3.0f);
        }
        StopCoroutine("SpawnBasic");
    }

     void SpawnBoss()
    {
        GameObject go = Instantiate(BossMonster, new Vector3(Player.position.x,Player.position.y,Player.position.z + 2.0f), Quaternion.identity);
        go.transform.parent = this.transform;
    }
}
