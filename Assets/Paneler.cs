using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paneler : MonoBehaviour {
    public GameObject[] panels;
    public int startpanel;
	// Use this for initialization
public void SetMenu (int index) {
        startpanel = index;
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject go in panels)
        {
            if (go == panels[startpanel])
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
	}
}
