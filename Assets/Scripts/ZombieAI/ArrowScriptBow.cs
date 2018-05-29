using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScriptBow : MonoBehaviour {

    public LayerMask layerMask; 
    public AudioClip soundHit;

    //public Trigger trigger;

    private Vector3 velocity = Vector3.zero; 	
    private Vector3 newPos = Vector3.zero;   
    private Vector3 oldPos = Vector3.zero;   	
    public bool hasHit = false;          	
    private Vector3 direction;               
    private RaycastHit hit;
    public float speed;
    public Transform arrowRotation;
    public float forceToApply;
    public float arrowGravity;
    private GameObject follow;
    public float projectileSpread = 0.1f;
    public float meleeDamage = 10.0f;

    // Use this for initialization
    void Start ()
    {
        newPos = transform.position;
        oldPos = newPos;
        velocity = speed * transform.forward;
        direction = transform.TransformDirection(new Vector3(Random.Range(-projectileSpread, projectileSpread), Random.Range(-projectileSpread, projectileSpread), 1));
    }

    // Update is called once per frame
    void Update () {

        //Destroy(gameObject, 0.7f);

        if (hasHit)
        {
            transform.position = follow.transform.position;
            transform.rotation = follow.transform.rotation;
            return;
        }


        newPos += (velocity + direction) * Time.deltaTime;

        Vector3 dir = newPos - oldPos;
        float dist = dir.magnitude;

        if (dist > 0)
        {
            
            if (Physics.Raycast(oldPos, dir, out hit, dist, layerMask))
            {
                newPos = hit.point;

                if (hit.collider)
                {
                   // trigger.activated = true;
                    GetComponent<AudioSource>().PlayOneShot(soundHit, 0.3f);

                    if (hit.rigidbody)
                    {
                        GameObject hitPoint = Instantiate(new GameObject(), hit.point, transform.root.rotation);
                        hitPoint.transform.parent = hit.transform;
                        follow = hitPoint;
                        hit.rigidbody.AddForceAtPosition(forceToApply * dir, hit.point);
                        hasHit = true; // если на false то физика увеличивает потенциал массы в разы
                    }else{
                        GetComponent<Collider>().isTrigger = false;
                        enabled = false;
                    }
                }

                hit.collider.SendMessageUpwards("ApplyDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
            }
        }


        oldPos = transform.position;
        transform.position = newPos;
        velocity.y -= arrowGravity * Time.deltaTime;
        arrowRotation.transform.rotation = Quaternion.LookRotation(dir);
    }

}

