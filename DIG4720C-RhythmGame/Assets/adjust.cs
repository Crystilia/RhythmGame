using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjust : MonoBehaviour {

    public SensorCore SC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SC.flexThreshold = SC.flexThreshold - 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SC.flexThreshold = SC.flexThreshold + 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SC.restThreshold = SC.restThreshold + 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SC.restThreshold = SC.restThreshold - 0.01f;
        }
    }
}
