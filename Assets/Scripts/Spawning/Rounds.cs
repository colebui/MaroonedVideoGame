using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    [SerializeField] static Spawner[] spawners;
    private static int roundNum = 0;
    private float timeBetweenChecks = 0.0f;
    //private static int enemysLeft;
    private static int newEnemyCount;
    public List<GameObject> enemysAlive = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //spawners.AddRange(GameObject.FindGameObjectsWithTag("Spawner"));
        spawners = FindObjectsOfType<Spawner>();
        Debug.Log("got all spawners: " + spawners.Length);
        enemysAlive.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        newRound();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenChecks += Time.deltaTime;
        if (timeBetweenChecks >= 5.0f)
        {
            timeBetweenChecks = 0.0f;
            enemysAlive.Clear();
            enemysAlive.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            Debug.Log("Enemy count updated " + enemysAlive.Count);


            if (enemysAlive.Count <= 0 && spawners[0].getEnemysSpawned() >= newEnemyCount)
            {
                newRound();
            }
        }
    }

    void newRound()
    {
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
        Debug.Log("Max enemys: " + newEnemyCount);
    }
}
