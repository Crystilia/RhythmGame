using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNote : MonoBehaviour {
    private Song_Generator sg;
	// Use this for initialization
	void Start () {
        sg = GameObject.Find("SongManager").GetComponent<Song_Generator>();
	}

    void OnTriggerEnter(Collider other)
    {
        sg.Rand(other.gameObject);
    }
}
