using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public bool activated = false;
	
	void OnTriggerStay(Collider other) {
        if (activated)
        {
            if (other.name == "Player" && Input.GetKey(KeyCode.E))
            {
                other.gameObject.BroadcastMessage("PickUpArrow");
                Destroy(transform.root.gameObject);
            }
        }
    }
}
