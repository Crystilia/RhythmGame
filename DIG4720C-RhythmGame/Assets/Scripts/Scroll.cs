using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	public GameObject songs;
	public GameObject song1;
	public GameObject song2;
	public GameObject song3;
	public GameObject song4;
	public GameObject song5;
	public GameObject song6;
	public GameObject song7;


	// Use this for initialization
	void Start (){
	}

	// Update is called once per frame
	void Update () {
		//move up
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))
		{
			songs.transform.Translate (0, 15, 0);
		}

		//too far up
		if (song1.transform.position.y > 46)
			song1.transform.position = new Vector3 (50.2342453f, -45.05953f, 74.96101f);
		if (song2.transform.position.y > 46)
			song2.transform.position = new Vector3 (50.2342453f, -45.05953f, 74.96101f);
		if (song3.transform.position.y > 46)
			song3.transform.position = new Vector3 (50.2342453f, -45.05953f, 74.96101f);
		if (song4.transform.position.y > 46)
			song4.transform.position = new Vector3 (50.2342453f, -45.05953f, 74.96101f);
		if (song5.transform.position.y > 46)
			song5.transform.position = new Vector3 (50.2342453f, -45.05953f, 74.96101f);
		if (song6.transform.position.y > 46)
			song6.transform.position = new Vector3 (50.2342453f, -45.05953f, 74.96101f);
		if (song7.transform.position.y > 46)
			song7.transform.position = new Vector3 (50.2342453f, -45.05953f, 74.96101f);
			
		//move down
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow))
		{
			songs.transform.Translate (0, -15, 0);
		}
			
		//too far down
		if (song7.transform.position.y < -46)
			song7.transform.position = new Vector3 (50.234246f, 45.05953f, 74.96101f);
		if (song6.transform.position.y < -46)
			song6.transform.position = new Vector3 (50.234246f, 45.05953f, 74.96101f);
		if (song5.transform.position.y < -46)
			song5.transform.position = new Vector3 (50.234246f, 45.05953f, 74.96101f);
		if (song4.transform.position.y < -46)
			song4.transform.position = new Vector3 (50.234246f, 45.05953f, 74.96101f);
		if (song3.transform.position.y < -46)
			song3.transform.position = new Vector3 (50.234246f, 45.05953f, 74.96101f);
		if (song2.transform.position.y < -46)
			song2.transform.position = new Vector3 (50.234246f, 45.05953f, 74.96101f);
		if (song1.transform.position.y < -46)
			song1.transform.position = new Vector3 (50.234246f, 45.05953f, 74.96101f);
	}
}
