using System.Collections;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Security.Cryptography;
//using System.Security.Policy;
using UnityEngine;

public class chestSpawner : MonoBehaviour
{
    [SerializeField] GameLogic gl;
    [SerializeField] AudioSource foundSound;
    [SerializeField] AudioClip foundClip;
    [SerializeField] AudioClip bluderbussUnlocked;
    [SerializeField] AudioClip speargunUnlocked;
    int chestType;
    // 0 = null, 1 = power weapon 1; 2 = power weapon 2; 3 = points; 4 = ammo
    void Start()
    {
        chestType = 0;
    }

    void changeState(bool io, int type)
    {
        chestType = type;
        Transform chestT = gameObject.transform;
        if (type == 0)
        {
            foreach (Transform child in chestT)
            {
                if (!child.name.Contains("Spawner"))
                    child.gameObject.SetActive(false);
            }
            return;
        }
        gameObject.transform.Find("mapIcon").gameObject.SetActive(io);
        if (type == 1)
        {
            gameObject.transform.Find("speargunChest").gameObject.SetActive(io);
        }
        else if (type == 2)
        {
            FindObjectOfType<Blunderbuss>().AddPowerWeapon();
            gameObject.transform.Find("blunderbussChest").gameObject.SetActive(io);
        }
        else if (type == 3)
        {
            gameObject.transform.Find("coinChest").gameObject.SetActive(io);
        }
        else if (type == 4) {
            gameObject.transform.Find("ammoChest").gameObject.SetActive(io);
        }
    }
    public void setState(int type)
    {
        chestType = type;
        if (type == 0)
        {
            changeState(false, type);
            return;
        }
        changeState(true, type);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            AudioClip sound = foundClip;
            if (chestType == 0)
            {
                return;
            }
            else if (chestType == 1)
            {
                sound = speargunUnlocked;
                Debug.Log("Picked up power weapon 1\n");
            }
            else if (chestType == 2)
            {
                sound = bluderbussUnlocked;
                Debug.Log("Picked up power weapon 2\n");
            }
            else if (chestType == 3)
            {
                Debug.Log("Picked up points\n");
                gl.addScore(420);
            }
            else if (chestType == 4)
            {
                Pistol.AddAmmo(20);
                Debug.Log("Picked up ammo \n");
            }
            else
            {
                Debug.Log("ERROR chestSpawner:onTrigger: Invalid chestType\n");
            }
            if (foundSound != null)
            {
                foundSound.PlayOneShot(sound, 4f);
            }
            FindObjectOfType<TreasureHuntMain>().chestFound();
            setState(0);
        }
    }
}