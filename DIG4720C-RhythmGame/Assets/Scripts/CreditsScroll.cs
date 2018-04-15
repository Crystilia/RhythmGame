using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour {
    public int height = 3000;
    public GameObject spawn;
	// Use this for initialization
	void Start () {
        this.transform.position = spawn.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < height)
		transform.Translate (0, 1, 0);
	
	}
}
