﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;

public class TreasureHuntMain : MonoBehaviour
{
    static bool activeChest; // Does the player have a map already?
    static int numberOfCompleted;
    [SerializeField] int frequency; // How often to get a map 1/n
    [SerializeField] int ammoFrequency; // How often to get a ammo chest (vs coins) 1/n
    [SerializeField] int chestsToGetPW1;
    [SerializeField] int chestsToGetPW2;

    [SerializeField] AudioSource mapSound;
    [SerializeField] AudioClip mapClip;
    
    GameObject[] spawners;
    // Start is called before the first frame update
    void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        activeChest = false;
        numberOfCompleted = 0;
        spawners = GameObject.FindGameObjectsWithTag("chestSpawner");
        for (int i = 0; i < spawners.Length; i++)
        {
            //Spawners cannot be deactivated in their start() functions. 
            spawners[i].GetComponent<chestSpawner>().setState(0);
        }
    }
    //call at start of new round
    public void roll()
    {
        if (activeChest)
        { //Don't run 2 treasure hunts concurrently
            return;
        }
        //Roll for chest
        //ints are not maximally inclusive; add 1
        int freq = Random.Range(0, frequency + 1);
        if (freq == 1 && frequency != 1)
            return;

        if (mapSound != null)
        {
            mapSound.PlayOneShot(mapClip, 2f);
        }
        activeChest = true;
        //Make the chest
        if (numberOfCompleted == chestsToGetPW1 || numberOfCompleted == chestsToGetPW2)
        {
            GameObject chestSpawners = GameObject.Find("ChestSpawners");
            if (numberOfCompleted == chestsToGetPW1)
            {
                chestSpawners.transform.Find("speargunSpawner").GetComponent<chestSpawner>().setState(1);
                Debug.Log("You got a power weapon 1 map\n");
            }
            else if (numberOfCompleted == chestsToGetPW2)
            {
                chestSpawners.transform.Find("blunderbussSpawner").GetComponent<chestSpawner>().setState(2);
                Debug.Log("You got a power weapon 2 map\n");
            }
        }
        else
        {
            int type = (Random.Range(0, ammoFrequency + 1) == 1 ? 4 : 3); 
            //ints are not maximally inclusive
            int no = Random.Range(0, spawners.Length);
            GameObject chest = spawners[no]; //grab a random chest spawner
            chest.GetComponent<chestSpawner>().setState(type);
            Debug.Log("You got a points or ammo map\n");
        }
        //select a chest to show
        //show notification on screen
    }
    public void chestFound()
    {
        numberOfCompleted++;
        activeChest = false;
    }
}