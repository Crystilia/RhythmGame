using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRotate : MonoBehaviour {
    public float speed = 15f;
    // Use this for initialization
    void Start () {
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CharSelect"))
        {
            this.enabled = true;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CharSelect2P"))
        {
            this.enabled = true;
        }
        else
        {
            this.enabled = false;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
