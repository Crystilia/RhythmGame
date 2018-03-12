using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour {
    Manager manager;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * manager.NoteSpeed;
    }
	
}
