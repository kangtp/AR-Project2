using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public bool canShoot = false;
    private Transform GoalPosition;
    public float Speed = 2.0f;
    private Vector3 forposi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void SetBulletPosition(Transform position)
    {
        canShoot = true;
        GoalPosition = position;
        forposi = (GoalPosition.position - transform.position).normalized;
        transform.parent = null; // 부모와 자식을 분리를 시켜 부모의 회전값이 자식에 영향이 가지않도록 하였다.
        StartCoroutine("DestroyitSelf");
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
        {
           //transform.position = Vector3.MoveTowards(this.transform.position,GoalPosition.position,bulletSpeed * Time.deltaTime);
           transform.position += forposi * Speed * Time.deltaTime;
        }
    }

      void OnTriggerEnter(Collider other) 
    {
        
    }

     IEnumerator DestroyitSelf()
    {  
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
