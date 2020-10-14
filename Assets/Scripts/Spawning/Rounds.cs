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
    [SerializeField] TextMeshProUGUI roundTitle;
    [SerializeField] TextMeshProUGUI scoreAdditionText;

    private int newEnemyCount = 0;
    [SerializeField] private int roundNum = 0;
    private float timeBetweenChecks = 0.0f;
    [SerializeField] private float timeBetweenRounds = 30.0f;
    private float timerForRounds = 0.0f;

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
        roundTitle.enabled = false;
        scoreAdditionText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //does every 5 seconds
        timeBetweenChecks += Time.deltaTime;
        if ((timeBetweenChecks >= 5.0f) || Input.GetKeyDown("space"))
        {
            //Debug.Log("Time between checks ellapsed");
            timeBetweenChecks = 0.0f;
            enemysAlive.Clear();
            enemysAlive.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            Debug.Log("Enemy count updated " + enemysAlive.Count);
            if (enemysAlive.Count <= 0)
            {
                timerForRounds += 5;
                //tell the player its an itermition 
                if ((timerForRounds >= timeBetweenRounds) || roundNum == 0 || Input.GetKeyDown("space"))
                {
                    newRound();
                    timerForRounds = 0;
                }

            }
        }
    }

    void newRound()
    {
        FindObjectOfType<TreasureHuntMain>().roll();
        GameLogic.Instance.addScore(roundPayout);
        roundNum++;
        Debug.Log("Round number " + roundNum);

        // Updates the round text
        roundText.text = "Round " + roundNum;
        StartCoroutine(ShowRoundTitle("Round " + roundNum, 2));
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
        newEnemyCount = (int)(Mathf.Ceil(Mathf.Floor(80.0f * Mathf.Pow(1.02f, roundNum)) - 78.0f) / 2) + 1;
        Debug.Log("Max enemys: " + newEnemyCount * 2);
    }
    IEnumerator ShowRoundTitle(string message, float delay)
    {
        roundTitle.text = message;
        roundTitle.enabled = true;
        scoreAdditionText.enabled = true;
        yield return new WaitForSeconds(delay);
        roundTitle.enabled = false;
        scoreAdditionText.enabled = false;
    }
}
