using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMonster : MonoBehaviour
{
    // Start is called before the first frame update
    public float AttackTimemin = 2.0f; //Attack minimum of random values
    public float AttackTimemax = 4.0f; //attack maximum of random values
    public GameObject Player;

    public GameObject Meteor;

    private ParticleSystem Circle;

    public Transform[] AttackArea; // Position that Spawn Meteor 

    public GameObject ice_age; // iceboss strong attack prefabs

    private bool canMake = true; // Control instantiate Monster

    private Animator animator;

    public int HP = 100; // Monster HP

    private int currentHp; // current Monstr HP

    public AudioClip[] audioClip;
    private AudioSource audioSource;

    [SerializeField] private MonsterHP_Bar HP_Bar; // Monster HPBar


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Find Player Object
        animator = GetComponent<Animator>();
        StartCoroutine("BasicAttack"); // start Basic Attack
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip[0];

        for (int i = 0; i < 3; i++)  // spawn Meteor
        {
            GameObject go = Instantiate(Meteor, AttackArea[i].position, Quaternion.identity); // Create meteors at each location
            go.transform.parent = AttackArea[i].transform; // put it as a child of AttackArea because control Bullet
        }
        Circle = this.gameObject.transform.GetChild(4).GetComponent<ParticleSystem>(); // particle is in Monster So that it is more easy to find Particle
        Circle.Stop(); // stop Particle
        currentHp = HP; // current HP has to be same as HP
        HP_Bar.UpdateHpbar(HP, currentHp); //Fill HP_Bar
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player != null)
        {
            // Rotates the current object towards the Player object
            transform.LookAt(Player.transform);
        }
        /* //it is a test for HP_bar and animation
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
        */

        if (currentHp < 31 && canMake) // if monster Hp is lower than 30 Monster will be Attack Strong
        {
            StopCoroutine("BasicAttack"); // stop Basic Attack behavior
            StartCoroutine("StrongAttack"); // start Strong Attack behavior
            Circle.Play(); // play particle
            canMake = false; // it should be enter Onetime
        }
    }

     public void HPControl(int Deal) // To control Hp_bar if Monster damaged Hp_Bar will reduce
    {
        currentHp -= Deal;
        HP_Bar.UpdateHpbar(HP,currentHp);
    }

     public int getHp() // to get HP that someone get Hp information in another script
    {
        return currentHp;
    }

    IEnumerator BasicAttack() // it is about Basic Monster Attack
    {
        while (true)
        {
            float randomValue = Random.Range(AttackTimemin, AttackTimemax); // Accept the random value of the attack time.
            yield return new WaitForSeconds(randomValue); // after random time
            if (animator.GetInteger("Condition") != 2)
            {
                audioSource.Play();
                animator.SetInteger("Condition", 1); // play Attack Animation
                int randomValueAttack = Random.Range(0, 3); // Decide which meteo will come out of the 3 locations.
                AttackArea[randomValueAttack].GetChild(0).GetComponent<Meteor>().SetBulletPosition(Player.transform); // Shoot a meteor at a randomly selected transform
                GameObject go = Instantiate(Meteor, AttackArea[randomValueAttack].position, Quaternion.identity); //Respawns after firing Meteor 
                go.transform.parent = AttackArea[randomValueAttack].transform; //put it as a child of AttackArea because control Meteor
                yield return new WaitForSeconds(0.1f);
                //StartCoroutine("SpawnMeteor");
            }
        }
    }

    IEnumerator StrongAttack()
    {
        while (true)
        {
            if (animator.GetInteger("Condition") != 2)
            {
                audioSource.clip = audioClip[1];
                audioSource.Play();
                animator.SetInteger("Condition", 1);
                GameObject go = Instantiate(ice_age,Player.transform.position,Quaternion.identity); // instantiate IceAge Prefabs it is a powerful skill
                //StartCoroutine("SpawnMeteor");
            }
             yield return new WaitForSeconds(5.0f);
        }
    }

/*
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
    */

    public void HitAnimation()
    {
        animator.SetInteger("Condition", 2);
    }
}
