using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Face_anim : MonoBehaviour {
    public Material[] Player;
   
    Vector2 myoffset;

    [Range(0, 7)]
    public int offset;

    public float _offset = 0.125f;
    // Use this for initialization
    void Start ()
    { 
    myoffset = new Vector2(_offset, 0);
        if (Player[0] != null) {
            Player[0].SetTextureOffset("_MainTex", myoffset);
        }
    }
    
	// Update is called once per frame
	void Update () {
       if (_offset != 0.125f * offset)
       {
            _offset = 0.125f * offset;
            myoffset.x = _offset;
            Player[0].SetTextureOffset("_MainTex", myoffset);
        }
	}
}