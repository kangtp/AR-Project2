using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : MonoBehaviour
{
    public float AttackTimemin = 2.0f; //attack 랜덤 값의 최소값
    public float AttackTimemax = 4.0f; //attack 랜덤 값의 최대값
    public GameObject Player;

    public GameObject Meteor;

    private ParticleSystem Circle;

    public Transform[] AttackArea;

    private bool canMake = true;

    private Animator animator;

    public int HP = 100;

    private int currentHp;

    [SerializeField] private MonsterHP_Bar HP_Bar;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        StartCoroutine("BasicAttack");

        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(Meteor, AttackArea[i].position, Quaternion.identity);
            go.transform.parent = AttackArea[i].transform;
        }
        Circle = this.gameObject.transform.GetChild(4).GetComponent<ParticleSystem>();
        Circle.Stop();
        currentHp = HP;
        HP_Bar.UpdateHpbar(HP,currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            // 현재 오브젝트를 Player 오브젝트를 향해 회전시킴
            transform.LookAt(Player.transform);
        }

        if (Input.GetKeyDown("w"))
        {
            currentHp = 20;
            HP_Bar.UpdateHpbar(HP,currentHp);
            //animator.SetInteger("Condition", 1);
        }
        else if (Input.GetKeyDown("d"))
        {
            animator.SetInteger("Condition", 2);
        }
        else
        {
            animator.SetInteger("Condition", 0);
        }

        if (currentHp < 31 && canMake)
        {
            StopCoroutine("BasicAttack");
            StartCoroutine("StrongAttack");
            Circle.Play();
            canMake = false;
        }
    }

     public void HPControl(int Deal)
    {
        currentHp -= Deal;
        HP_Bar.UpdateHpbar(HP,currentHp);
    }

     public int getHp()
    {
        return currentHp;
    }
    IEnumerator BasicAttack()
    {
        while (true)
        {
            float randomValue = Random.Range(AttackTimemin, AttackTimemax);
            yield return new WaitForSeconds(randomValue);
            if (animator.GetInteger("Condition") != 2)
            {
                animator.SetInteger("Condition", 1);
                int randomValueAttack = Random.Range(0, 3);
                AttackArea[randomValueAttack].GetChild(0).GetComponent<Meteor>().SetBulletPosition(Player.transform);
                GameObject go = Instantiate(Meteor, AttackArea[randomValueAttack].position, Quaternion.identity);
                go.transform.parent = AttackArea[randomValueAttack].transform;
                yield return new WaitForSeconds(0.1f);
                //StartCoroutine("SpawnMeteor");
            }
        }
    }

    IEnumerator StrongAttack()
    {
        while (true)
        {
            float randomValue = Random.Range(AttackTimemin, AttackTimemax);
            yield return new WaitForSeconds(3.0f);
            if (animator.GetInteger("Condition") != 2)
            {
                animator.SetInteger("Condition", 1);
                int randomValueAttack = Random.Range(0, 3);
                for (int i = 0; i < 20; i++)
                {
                    AttackArea[randomValueAttack].GetChild(0).GetComponent<Meteor>().SetBulletPosition(Player.transform);
                    GameObject go = Instantiate(Meteor, AttackArea[randomValueAttack].position, Quaternion.identity);
                    go.transform.parent = AttackArea[randomValueAttack].transform;
                    yield return new WaitForSeconds(0.1f);
                }
                //StartCoroutine("SpawnMeteor");
            }
        }
    }

    IEnumerator SpawnMeteor()
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < 3; i++)
        {
            if (AttackArea[i].transform.childCount < 1)
            {
                GameObject go = Instantiate(Meteor, AttackArea[i].position, Quaternion.identity);
                go.transform.parent = AttackArea[i].transform;
            }
        }
    }

    public void HitAnimation()
    {
        animator.SetInteger("Condition", 2);
    }
}
