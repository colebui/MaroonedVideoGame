using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : Rounds
{
    [SerializeField] GameObject spawnee;
    [SerializeField] bool stopSpawning = false;
    [SerializeField] float spawnTime = 1;
    [SerializeField] float spawnDelay = 2;
    private int enemysSpawned;
    [SerializeField] int maxSpawn;

    // Start is called before the first frame update
    void Start()
    {
        enemysSpawned = 0;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObject()
    {
        //base.newEnemy();
        if (stopSpawning||maxSpawn <= enemysSpawned)
        {
            CancelInvoke("SpawnObject");
        }
        enemysSpawned++;
        if(maxSpawn <= enemysSpawned)
        {
            stopSpawning = true;
        }

        //needs to be the last thing in the method 
        Instantiate(spawnee, transform.position, transform.rotation);
    }
    
    public void startNewRound()
    {
        stopSpawning = false;
        enemysSpawned = 0;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    //getters
    public int getEnemysSpawned()
    {
        return enemysSpawned;
    }

    //setters
    public void setMaxSpawn(int max)
    {
        maxSpawn = max;
    }

    
}
