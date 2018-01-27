using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour {
    float constantSpeed = 7f;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = constantSpeed * (rb.velocity.normalized);
       // Debug.Log(this.GetComponent<Rigidbody>().velocity);
	}
}
