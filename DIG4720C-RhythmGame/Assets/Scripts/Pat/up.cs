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
    public Vector3 RemovePos;
    public Transform SpawnPos;
    public GameObject spawn;


    // Use this for initialization
    void Start () {


        manager = GameObject.Find("Manager").GetComponent<Manager>();
        RemovePos = new Vector3(this.transform.position.x, manager.P1.transform.position.y+500f, this.transform.position.z);
        rb = this.GetComponent<Rigidbody2D>();
        curC = this.GetComponent<MeshRenderer>().material;
        if (active)
        {
            SpawnPos=this.transform;


            //RESET MANAGER NOTE SPREAD Y TO 2.3 ***************
            //RESET NOTE SPAWN Y TO -1723
             rb.velocity = Vector2.up * manager.NoteSpeed;
            //***************************************


            //Testing MANAGER NOTE SPREAD Y 4***************
            //RESET NOTE SPAWN Y TO -3510
            // rb.velocity = Vector2.up * manager.NoteSpeed;
            //***************************************
        }
    }
    private void Update()
    {

        if (bomb)
        {
            rate = (Mathf.Sin(Time.time / speed));
            curC.color = Color.Lerp(startC, nextC, rate);
        }
     //   if (active && Time.timeScale == 1)
      //  {
            //transform.position = Vector3.MoveTowards(SpawnPos.position, RemovePos, );
        //    transform.position = Vector3.MoveTowards(SpawnPos.position, RemovePos, ((float)AudioSettings.dspTime/4500));
     //   }
    }

}
///(float) (AudioSettings.dspTime*
                                  