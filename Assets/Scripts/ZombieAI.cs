using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour {

    public Transform target; //the enemy's target
     public int moveSpeed = 3; //move speed
    public int rotationSpeed = 3; //speed of turning
    public double attackThreshold = 1.5; // distance within which to attack
    public int chaseThreshold = 10; // distance within which to start chasing
    public int giveUpThreshold = 20; // distance beyond which AI gives up
    public float attackRepeatTime = 1; // delay between attacks when within range
    public double Damage = 0.001;
    private bool chasing = false;
    public float attackTime = 10;
    public Transform myTransform; //current transform data of this enemy
  
     void Awake()
    {
        myTransform = transform; //cache transform data for easy access/preformance
    }

    void Start()
    {
        if (target == null && GameObject.FindWithTag("Player"))
            target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        var distance = (target.position - myTransform.position).magnitude;

        if (chasing)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

            if (distance > giveUpThreshold)
            {
                chasing = false;
            }

            if (distance < attackThreshold && Time.time > attackRepeatTime)
            {
                target.SendMessageUpwards("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
            }
            if (distance < attackThreshold)
            {
                moveSpeed = 0;
            }
            attackTime = Time.time + attackRepeatTime;
        }
        else
        {
            if (distance < chaseThreshold)
            {
                chasing = true;
            }
        }
    }
}

