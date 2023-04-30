using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    private Animator animator;

    public float attackDistance = 6f; // 공격 가능한 거리

    public float Speed = 2.0f;

    public float AttackTimemin = 2.0f; //attack 랜덤 값의 최소값
    public float AttackTimemax = 4.0f; //attack 랜덤 값의 최대값

    public GameObject Bullet;

    public Transform AttackArea;

    private AudioSource audioSource;
    public AudioClip[] audioClip;
    
    private bool CanAttack = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip[0];
        CanAttack = false;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator.SetBool("Attack", false);
        StartCoroutine("BasicAttack");
    }

    IEnumerator BasicAttack()
    {
        while (true)
        {
            float randomValue = Random.Range(AttackTimemin, AttackTimemax);
            yield return new WaitForSeconds(randomValue);
            if (!animator.GetBool("Attack") && CanAttack)
            {
                animator.SetBool("Attack", true);
                audioSource.Play();
                GameObject go = Instantiate(Bullet, AttackArea.position, Quaternion.identity);
                go.transform.parent = AttackArea.transform;
                AttackArea.GetChild(0).GetComponent<Meteor>().SetBulletPosition(player.transform);
                yield return new WaitForSeconds(0.1f);
                //StartCoroutine("SpawnMeteor");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform);
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
        }
        if (distance > attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
            CanAttack = false;
        }
        else
        {
            CanAttack = true;
        }
    }
}
