using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllZombieAI : MonoBehaviour {

    public Transform target; //the enemy's target
    public float moveSpeed = 2; //move speed
    public float rotationSpeed = 8; //speed of turning
    public int attackRange = 2; // distance within which to attack
    public int chaseRange = 10; // distance within which to start chasing
    public int giveUpRange = 20; // distance beyond which AI gives up
    public float attackRepeatTime = 1.5f; // delay between attacks when within range
    public GameObject anim;
    public float maximumHitPoints = 5.0f;
    public float hitPoints = 5.0f;
    public AudioClip attack;
    private bool chasing = false;
    private float attackTime;
    public bool checkRay = false;
    public string idleAnim = "idle";
    public string walkAnim = "walk";
    public string attackAnim = "attack";
    public string neckBitekAnim = "neck_bite";
    public int dontComeCloserRange = 4;

    public Vector3 direction; // Направляем npc по оси z в инспекторе

    private Transform myTransform; //current transform data of this enemy
    private ScoreManager scoreManager;
    //  public HealthScript hp;

    //  AudioSource audioSource;
    void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
        anim.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        anim.GetComponent<Animation>()[attackAnim].wrapMode = WrapMode.Once;
        anim.GetComponent<Animation>()[attackAnim].layer = 2;
        anim.GetComponent<Animation>().Stop();
    }

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
        //   audioSource = GetComponent<AudioSource>();
        if (scoreManager == null)
            scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scoreManager.playerDead)
        {
            // check distance to target every frame:
            var distance = (target.position - myTransform.position).magnitude;

            // Проверка на то что таргета не в зоне видимости по этому скорость снижена до 0 и проигроывается анимация idle
            // if (distance < dontComeCloserRange)
            // {
            //     moveSpeed = 0;
            //     anim.GetComponent<Animation>()[idleAnim].speed = .4f;
            //     anim.GetComponent<Animation>().CrossFade(idleAnim);
            // }
            // else
            // {
            //     //moveSpeed = Random.Range(0.1f, 0.4f);
            //     moveSpeed = Random.Range(0.5f, 0.7f);
            //     anim.GetComponent<Animation>().CrossFade(walkAnim);
            // }

            moveSpeed = Random.Range(0.5f, 0.7f); // скорость без проверки на дистаницю 
            anim.GetComponent<Animation>().CrossFade(walkAnim); // проигрывание анимации walk

            if (chasing)
            {
                //move towards the player
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;


                //rotate to look at the player
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

                // give up, if too far away from target:
                if (distance > giveUpRange)
                {
                    chasing = false;
                }

                // attack, if close enough, and if time is OK:
                if (distance < attackRange && Time.time > attackTime)
                {
                    moveSpeed = 0;
                    anim.GetComponent<Animation>()[attackAnim].speed = 1.0f;
                    anim.GetComponent<Animation>().CrossFade(attackAnim);

                    if (anim.GetComponent<Animation>()[attackAnim].time > 1.0f)
                    {

                        target.SendMessage("PlayerDamage", maximumHitPoints);
                        attackTime = Time.time + attackRepeatTime;
                    }
                    //audioSource.PlayOneShot(attack, 1.0f / audioSource.volume);
                }

            }
            else
            {
                // not currently chasing.       
                // Требуется для того чтобы npc проигрывал анимацию walk когда идёт по оси 
                // anim.GetComponent<Animation>()[idleAnim].speed = .4f;
                // anim.GetComponent<Animation>().CrossFade(idleAnim);

                myTransform.Translate(direction * moveSpeed * Time.deltaTime); // движение npc по оси вперёд не по таргету
                                                                             // start chasing if target comes close enough
                if (distance < chaseRange)
                {
                    chasing = true;
                }
            }
        }
        else
        {
            myTransform.Translate(direction * moveSpeed * Time.deltaTime); // иначе если герой мёртв то npc идёт вперёд (стоит ли это делать!?)
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}



//public Vector3 direction; // Направляем npc по оси z в инспекторе
//
//        // Проверка на то что таргета не в зоне видимости по этому скорость снижена до 0 и проигроывается анимация idle
//       // if (distance < dontComeCloserRange)
//       // {
//       //     moveSpeed = 0;
//       //     
//       //     anim.GetComponent<Animation>()[idleAnim].speed = .4f;
//       //     anim.GetComponent<Animation>().CrossFade(idleAnim);
//       // }
//        if (distance<dontComeCloserRange)
//        {
//            moveSpeed = Random.Range(0.5f, 0.7f);
//            anim.GetComponent<Animation>().CrossFade(walkAnim);
//            transform.Translate(direction * moveSpeed * Time.deltaTime);
//        }
//        else
//        {
//            moveSpeed = Random.Range(0.5f, 0.7f);
//            anim.GetComponent<Animation>().CrossFade(walkAnim);
//        }
//
//
//        // not currently chasing.
//        // Требуется для того чтобы npc проигрывал анимацию walk когда идёт по оси 
//        anim.GetComponent<Animation>()[idleAnim].speed = .4f;
//        anim.GetComponent<Animation>().CrossFade(idleAnim);
//
////      transform.Translate(direction * moveSpeed * Time.deltaTime);

