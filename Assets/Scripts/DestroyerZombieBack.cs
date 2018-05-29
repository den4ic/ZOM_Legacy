using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerZombieBack : MonoBehaviour {

    public GameObject EnemyDestructionPoint;
    private ScoreManager scoreManager;

    void Start()
    {
        EnemyDestructionPoint = GameObject.Find("EnemyDestructionPoint");
        if (scoreManager == null)
            scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (!scoreManager.playerDead)
        {
            if (transform.position.z < EnemyDestructionPoint.transform.position.z)
            {
                Destroy(gameObject);
              //gameObject.SetActive(false);
            }
        } else if (scoreManager.playerDead)
        {
            EnemyDestructionPoint = null;
        }
    } 
}
