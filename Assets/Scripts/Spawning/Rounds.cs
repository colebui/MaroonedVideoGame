using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    [SerializeField] static Spawner[] spawners;
    private static int roundNum;
    private static int enemysLeft;
    private static int newEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        roundNum = 1;
        newRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemysLeft <= 0)
        {
            roundNum++;
            newRound();
        }
    }

    void newRound()
    {
        calculateEnemyAmount();
        for (int i = 0; i < spawners.Length; i++)
        {
            //add if in range of player here

            spawners[i].setMaxSpawn(newEnemyCount);
            spawners[i].startNewRound();
        }
    }

    public void newEnemy()
    {
        enemysLeft++;
    }

    void calculateEnemyAmount()
    {
        if (newEnemyCount > 9)
        {
            newEnemyCount++;
        }
        else
        {
            newEnemyCount = (int)Mathf.Floor((1 / 5) * roundNum + roundNum);
        }

    }
}
