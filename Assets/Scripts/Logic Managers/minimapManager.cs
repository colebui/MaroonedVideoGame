using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapManager : MonoBehaviour
{ 
    GameObject caveCam;
    GameObject surfaceCam;
    // Start is called before the first frame update
    void Start()
    {
        caveCam = GameObject.Find("CaveMinimapCamera");
        surfaceCam = GameObject.Find("IslandMinimapCamera");
    }
    //GameObject.Find("/Managers/MinimapManager").GetComponent<minimapManager>().setToCave();
    public void setToSurface() {
        surfaceCam.SetActive(true);
        caveCam.SetActive(false); 
    }
    public void setToCave() {
        surfaceCam.SetActive(false);
        caveCam.SetActive(true);
    }
}
