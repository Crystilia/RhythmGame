using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour {

    private Rigidbody RB;
    // Use this for initialization
    private void Start()
    {
        RB = this.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        RB.AddForce(Vector3.up * 20);
        Debug.Log(RB.velocity);
    }
}
