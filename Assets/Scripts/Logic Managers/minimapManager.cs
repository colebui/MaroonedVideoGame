using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapManager : MonoBehaviour
{ 
    GameObject caveCam;
    GameObject surfaceCam;

    GameObject bigMap;
    bool isBig; 
    public static bool isInCave;
    // Start is called before the first frame update
    void Start()
    {
        isBig = false;
        isInCave = false; 
        bigMap = GameObject.Find("bigMap");
        bigMap.SetActive(false);
        caveCam = GameObject.Find("CaveMinimapCamera");
        surfaceCam = GameObject.Find("IslandMinimapCamera");

        setToSurface();
    }
    void Update() {
        if (Input.GetButtonDown("bigMap")) {
            bigMap.SetActive(isBig);
            isBig = !isBig;
        }
    }
    //GameObject.Find("/Managers/MinimapManager").GetComponent<minimapManager>().setToCave();
    public void setToSurface() {
        isInCave = false; 
        surfaceCam.SetActive(true);
        caveCam.SetActive(false);
        TreasureHuntMain hunt = FindObjectOfType<TreasureHuntMain>();
        if (!hunt.IsActive())
            return;
        if (hunt.isSurfaceChest())
        {
            hunt.modifyChestIcon(true);
        }
        else
        {
            hunt.modifyChestIcon(false);
            hunt.modifyXMarks(true);
        }
    }
    public void setToCave() {
        isInCave = true;
        surfaceCam.SetActive(false);
        caveCam.SetActive(true);
        TreasureHuntMain hunt = FindObjectOfType<TreasureHuntMain>();
        hunt.modifyXMarks(false);
        if (!hunt.IsActive())
            return;
        if (hunt.isSurfaceChest())
        {
            hunt.modifyChestIcon(false);
        }
        else
        {
            hunt.modifyChestIcon(true);
        }
    }
    public bool inCave() {
        return isInCave; 
    }
}
