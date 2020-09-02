using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
//using System.Media;
using System.Collections.Specialized;
using System.IO;

public class Rounds : MonoBehaviour
{

    [SerializeField] Spawner[] spawners;
    [SerializeField] int roundPayout = 1000;
    [SerializeField] TextMeshProUGUI roundText;

    private int newEnemyCount = 0;
    [SerializeField] private int roundNum = 0;
    private float timeBetweenChecks = 0.0f;

    public List<GameObject> enemysAlive = new List<GameObject>();

    void Start()
    {
        //spawners.AddRange(GameObject.FindGameObjectsWithTag("Spawner"));
        spawners = FindObjectsOfType<Spawner>();
        Debug.Log("got all spawners: " + spawners.Length);
        enemysAlive.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        //newRound();

        // Updates the round text
        roundText.text = "Round " + roundNum;
    }

    // Update is called once per frame
    void Update()
    {
        //does every 5 seconds
        timeBetweenChecks += Time.deltaTime;
        if (timeBetweenChecks >= 5.0f)
        {
            //Debug.Log("Time between checks ellapsed");
            timeBetweenChecks = 0.0f;
            enemysAlive.Clear();
            enemysAlive.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            Debug.Log("Enemy count updated " + enemysAlive.Count);
            if (enemysAlive.Count <= 0)
            {
                newRound();
            }
        }
    }

    void newRound()
    {
        FindObjectOfType<GameLogic>().addScore(roundPayout);
        roundNum++;
        Debug.Log("Round number " + roundNum);

        // Updates the round text
        roundText.text = "Round " + roundNum;

        calculateEnemyAmount();
        Spawner[] currentSpawns = findBestSpawns();
        for (int i = 0; i < spawners.Length; i++)
        {
            //add if in range of player here
            spawners[i].setMaxSpawn(0);
        }
        for (int i = 0; i < currentSpawns.Length; i++)
        {
            //add if in range of player here
            currentSpawns[i].setMaxSpawn(newEnemyCount);
        }
        for (int i = 0; i < spawners.Length; i++)
        {
            //add if in range of player here
            spawners[i].startNewRound();
        }

    }

    /*public void newEnemy()
    {
        enemysLeft++;
        
    }*/

    // Finds the two closest spawns to the player
    Spawner[] findBestSpawns()
    {

        Vector3 playerPos = GameObject.FindWithTag("MainCamera").transform.position;
        float distance = 0;
        Spawner[] returns = new Spawner[2];
        float[] returnsDistance = { float.MaxValue, float.MaxValue };
        for (int i = 0; i < spawners.Length; i++)
        {
            distance = Vector3.Distance(playerPos, spawners[i].transform.position);
            float maximum = Mathf.Max(returnsDistance);
            if (maximum > distance)
            {
                // Found a closer spawn, update
                returns[Array.IndexOf(returnsDistance, maximum)] = spawners[i];
                returnsDistance[Array.IndexOf(returnsDistance, maximum)] = distance;
            }
        }
        return returns;
    }
    void calculateEnemyAmount()
    {
        if (newEnemyCount > 9)
        {
            newEnemyCount++;
        }
        else
        {
            newEnemyCount = (int)Mathf.Floor((1 / 5) * roundNum) + roundNum;
        }
        Debug.Log("Max enemys: " + newEnemyCount * spawners.Length);
    }
}
