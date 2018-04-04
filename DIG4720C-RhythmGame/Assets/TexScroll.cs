using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexScroll : MonoBehaviour {

    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;

    public float ScrollX2 = 0.5f;
    public float ScrollY2 = 0.5f;
    float offsetX;
    float offsetY;
    float offsetX2;
    float offsetY2;

    private Material anim;
    Vector2 offset;
    Vector2 offset2;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Renderer>().material;
        
    }
	
	// Update is called once per frame
	void Update () {
        offsetX = Time.time * ScrollX;
        offsetY = Time.time * ScrollY;
        offset = new Vector2(offsetX, offsetY);
        anim.SetTextureOffset("_Overlay1", offset);
        offsetX2 = Time.time * ScrollX2;
        offsetY2 = Time.time * ScrollY2;
        offset2 = new Vector2(-offsetX2, -offsetY2);
        anim.SetTextureOffset("_Overlay2", offset2);
    }
}
