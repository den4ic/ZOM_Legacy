using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyNpc : MonoBehaviour
{
    private ScoreManager checkAlive;       // Reference to the player's heatlh.
    public GameObject[] enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        checkAlive = FindObjectOfType<ScoreManager>();
    }


    void Spawn()
    {
        // If the player has no health left...
        if (checkAlive.playerDead)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        int rand = Random.Range(0, enemy.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy[rand], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}