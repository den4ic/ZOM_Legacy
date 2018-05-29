using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunitions : MonoBehaviour {

    public GameObject AmmoBow;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            //GameObject.Find("Bow").GetComponent<BowScript>().arrowCount++;
            AmmoBow.GetComponent<BowScript>().arrowCount++;
        }
    }
}
