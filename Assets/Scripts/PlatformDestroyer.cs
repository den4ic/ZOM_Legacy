using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject PlatformDestructionPoint;
    private ScoreManager scoreManager;

    void Start () {
        PlatformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        if (scoreManager == null)
            scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

	void Update () {

        if (!scoreManager.playerDead)
        { 
            if (transform.position.z < PlatformDestructionPoint.transform.position.z)
            {
                Destroy(gameObject);
                //gameObject.SetActive(false);
            }
        }
        else 
        {
            PlatformDestructionPoint = null;
        }
    }
}
