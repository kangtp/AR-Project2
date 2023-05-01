using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // this script is about Bullet that Monster Shoot 
    public bool canShoot = false;
    private Transform GoalPosition;
    public float Speed = 0.5f; // Meteor Speed
    private Vector3 forposi; // Player Direction in Meteor
    // Start is called before the first frame update

     public void SetBulletPosition(Transform position) // get Bullet Spawn position
    {
        canShoot = true;
        GoalPosition = position;
        forposi = (GoalPosition.position - transform.position).normalized; //normalized Player position and Meteor position
        transform.parent = null; // By separating the parent and child, the rotation value of the parent does not affect the child.
        StartCoroutine("DestroyitSelf"); // Destroy Meteor
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
        {
           //transform.position = Vector3.MoveTowards(this.transform.position,GoalPosition.position,bulletSpeed * Time.deltaTime);
           transform.position += forposi * Speed * Time.deltaTime; // shoot meteor to player
        }
    }


     IEnumerator DestroyitSelf() //Destroy Meteor after 2sec
    {  
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
