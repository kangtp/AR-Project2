using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceage : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] SpawnIceObject;
    public float spawnRadius = 5.0f;
    public float spawnHeight = 2.0f;

    private bool death = false;

    public int NumofIce = 10;

    void Start()
    {
        StartCoroutine("SpawnIce");
        StartCoroutine("DestroyIce");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GetRandomPositionOnCircle(float radius)
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0; // y축을 0으로 고정하여 원형 형태로 생성

        float r = Random.Range(0.0f, radius);
        return (randomDirection * r) + transform.position;
    }

    IEnumerator SpawnIce()
    {
        if (!death)
        {
            while (true)
            {
                Vector3 spawnPosition = GetRandomPositionOnCircle(spawnRadius);
                spawnPosition.y = spawnHeight; // 높이 조정
                int randomValue = Random.Range(0, 2);
                Debug.Log(spawnPosition);
                GameObject go = Instantiate(SpawnIceObject[randomValue], spawnPosition, Quaternion.identity);
                go.transform.parent = this.transform;
                //SpawnIceObject[randomValue].transform.parent = this.transform;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    IEnumerator DestroyIce()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
