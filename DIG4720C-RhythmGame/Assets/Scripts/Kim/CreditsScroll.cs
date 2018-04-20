using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditsScroll : MonoBehaviour
{
    public int height = 950;
    public GameObject spawn;
    // Use this for initialization
    void Start()
    {
      //  this.transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < height)
        {
            transform.Translate(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
        
        }
        if(transform.position.y >= height)
        {
            SceneManager.LoadScene(0);
        }
    }
}
