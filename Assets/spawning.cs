using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject NPC_1;

    public float spawnDelay = 2f;      // time between spawns
    public int maxSpawns = 5;          // max NPCs allowed
    private float timer = 0f;
    private int currentSpawns = 0;     // how many have been spawned

    void Update()
    {
        // Stop if we've hit the max
        if (currentSpawns >= maxSpawns)
            return;

        // Count up time
        timer += Time.deltaTime;

        // Time to spawn?
        if (timer >= spawnDelay)
        {
            float x = Random.Range(0f, 6f);
            float y = Random.Range(0f, 6f);
            Vector3 spawnPos = new Vector3(x, 0, y);

            Instantiate(NPC_1, spawnPos, Quaternion.identity);

            currentSpawns++;   // track how many spawned
            timer = 0f;        // reset timer
        }
    }
}