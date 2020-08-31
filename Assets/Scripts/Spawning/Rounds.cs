using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    
    [SerializeField] Spawner[] spawners;
    [SerializeField] int roundPayout = 1000;
    
    private int newEnemyCount = 0;
    private int roundNum = 0;
    private float timeBetweenChecks = 0.0f;

    public List<GameObject> enemysAlive = new List<GameObject>();
    public bool readyForNewRound = false;

    void Start()
    {
        //spawners.AddRange(GameObject.FindGameObjectsWithTag("Spawner"));
        spawners = FindObjectsOfType<Spawner>();
        Debug.Log("got all spawners: " + spawners.Length);
        enemysAlive.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        //newRound();
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

            for(int i = 0; i< spawners.Length; i++)
            {
                if(spawners[i].getEnemysSpawned() >= newEnemyCount)
                {
                    //Debug.Log("We are ready for a new round");
                    readyForNewRound = true;
                }
                else
                {
                    readyForNewRound = false;
                    break;
                }
            }
            if (enemysAlive.Count <= 0 && readyForNewRound)
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
        calculateEnemyAmount();
        for (int i = 0; i < spawners.Length; i++)
        {
            //add if in range of player here

            spawners[i].setMaxSpawn(newEnemyCount);
            spawners[i].startNewRound();
        }

    }

    /*public void newEnemy()
    {
        enemysLeft++;
        
    }*/

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
