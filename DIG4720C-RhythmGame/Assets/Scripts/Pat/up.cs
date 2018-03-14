using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour {
    Manager manager;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * manager.NoteSpeed;
    }
	
}
