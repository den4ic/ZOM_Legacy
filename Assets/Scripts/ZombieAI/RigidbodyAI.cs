using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyAI : MonoBehaviour {
    public float maxSpeed = 7.000f;
    public float force = 8.000f;

    void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward);
            GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.right);
        }
    }
}
