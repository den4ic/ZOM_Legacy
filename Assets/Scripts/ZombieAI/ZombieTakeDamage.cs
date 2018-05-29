using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTakeDamage : MonoBehaviour {

    public float maximumHitPoints = 100.0f;
    public float hitPoints = 100.0f;
    public Rigidbody deadReplacement;
    public GameObject GOPos;

    void Start()
    {
        // theArrow = FindObjectOfType<ArrowScriptBow>().DestroyArrow();
        // ArrowScriptBow.DestroyObject(gameObject);
    }

    void ApplyDamage(float damage)
    {
        if (hitPoints <= 0.0)
            return;

        // Apply damage
        hitPoints -= damage;
        //scoreManager.DrawCrosshair();
        // Are we dead?
        if (hitPoints <= 0.0)
            // gameObject.GetComponent<ArrowScriptBow>().hasHit = false;
            //GetComponent<ZombieTakeDamage>.DestroyArrow();
        Replace();
    }

    void Replace()
    {

        // If we have a dead barrel then replace ourselves with it!
        if (deadReplacement)
        {
            Rigidbody dead = Instantiate(deadReplacement, GOPos.transform.position, GOPos.transform.rotation);
            //scoreManager.addScore(20);
            // For better effect we assign the same velocity to the exploded barrel
            dead.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            dead.angularVelocity = GetComponent<Rigidbody>().angularVelocity;
        }
        // Destroy ourselves
        Destroy(gameObject);
    }
}