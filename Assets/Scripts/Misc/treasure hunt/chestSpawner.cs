using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestSpawner : MonoBehaviour
{
    [SerializeField] GameLogic gl; 
    int chestType;
    [SerializeField]
    // 0 = null, 1 = points, 2 = power weapon, 3 = ammo (if needed)
    void Start()
    {
        chestType = 0;
        //gameObject.SetActive(false);
    }
    void collided() {
        if (chestType == 0)
            return;
        if (chestType == 1) { 
            //give player points
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            gl.addScore(420);
            chestType = 0;
            gameObject.SetActive(false);
        }
    }
}
