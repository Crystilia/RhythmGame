using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour {
    Manager manager;
    public Rigidbody2D rb;
    public bool bomb = false;
    private Material curC;
    public Color startC;
    public Color nextC;
    public float speed;
    public float rate;
    public bool active = true;
    // Use this for initialization
    void Start () {

        manager = GameObject.Find("Manager").GetComponent<Manager>();
        rb = this.GetComponent<Rigidbody2D>();
        curC = this.GetComponent<MeshRenderer>().material;
        if (active)
        {
            rb.velocity = Vector2.up * manager.NoteSpeed;
        }
    }
    private void Update()
    {
        if(bomb)
        {
            rate = (Mathf.Sin(Time.time / speed));
            curC.color = Color.Lerp(startC, nextC, rate);
        }
    }

}
