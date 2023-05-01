using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    private Animator animator;

    public float attackDistance = 6f; // attack range

    public float Speed = 2.0f; // bullet Speed

    public float AttackTimemin = 2.0f; //Attack minimum of random values
    public float AttackTimemax = 4.0f; //attack maximum of random values

    public GameObject Bullet;

    public Transform AttackArea; // Instantiate Bullet where you spawn it

    private AudioSource audioSource;
    public AudioClip[] audioClip;
    
    private bool CanAttack = false; // control Attack

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip[0];
        CanAttack = false;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator.SetBool("Attack", false); // set animation default value -> Idle
        StartCoroutine("BasicAttack"); // Start Attack behavior
    }

    IEnumerator BasicAttack() // it is about Basic Monster Attack
    {
        while (true)
        {
            float randomValue = Random.Range(AttackTimemin, AttackTimemax); // Accept the random value of the attack time.
            yield return new WaitForSeconds(randomValue);
            if (!animator.GetBool("Attack") && CanAttack) // if basicmonster is not attacking
            {
                animator.SetBool("Attack", true); // play Attack Animation
                audioSource.Play();
                GameObject go = Instantiate(Bullet, AttackArea.position, Quaternion.identity);
                go.transform.parent = AttackArea.transform; // put it as a child of AttackArea because control Bullet
                AttackArea.GetChild(0).GetComponent<Meteor>().SetBulletPosition(player.transform); // setBulletPosition
                yield return new WaitForSeconds(0.1f);
                //StartCoroutine("SpawnMeteor");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform);
        float distance = Vector3.Distance(transform.position, player.transform.position); //Distance between player and monster

        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false); // change value if Monster Attack (Attack -> Idle)
        }
        if (distance > attackDistance) // Behavior of monsters when entering attack range (not entering)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime); // if attack range is out of range Monster follow Player
            CanAttack = false; // control Monster Attack because Monster can't Attack that it is not in Attack range
        }
        else // Behavior of monsters when entering attack range
        {
            CanAttack = true;
        }
    }
}
