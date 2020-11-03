using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CurrentUpgradeVisual : MonoSingleton<CurrentUpgradeVisual> {
    [SerializeField] List<GameObject> levelsVisualList= new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CurrentUpgradeVisual instantiated");
    }

    public void initializeLevelsVisuals() {
        Debug.Log("childcount " + gameObject.transform.childCount);
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            Debug.Log(gameObject.transform.GetChild(i).gameObject);
            levelsVisualList.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    public void updateLevelsVisualList(int level) {
        //int level = 1; //change this
        Debug.Log("updating color level: "+level);
        for (int i = 0; i < level; i++) {
            levelsVisualList[i].GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
    }
}
