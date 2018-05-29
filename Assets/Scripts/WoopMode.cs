using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoopMode : MonoBehaviour {
	public Transform Points;
	public GameObject Prefabs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			Instantiate (Prefabs, Points.position, Quaternion.identity);
			//Destroy (gameObject);
		}
	}
}
