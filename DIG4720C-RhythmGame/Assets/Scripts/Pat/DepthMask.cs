using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthMask : MonoBehaviour {
    Renderer render;
    void Start()
    {
         render = GetComponent<Renderer>();
        render.material.renderQueue = 3000;
    }
}