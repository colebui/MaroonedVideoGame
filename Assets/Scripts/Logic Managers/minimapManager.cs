using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapManager : MonoBehaviour
{ 
    GameObject caveCam;
    GameObject surfaceCam;
    public static bool isInCave;
    // Start is called before the first frame update
    void Start()
    {
        isInCave = false; 
        caveCam = GameObject.Find("CaveMinimapCamera");
        surfaceCam = GameObject.Find("IslandMinimapCamera");
        setToSurface();
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
