using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTest : MonoBehaviour {

	public GameObject songs;
	public GameObject song1;
	public GameObject song2;
	public GameObject song3;
	public GameObject song4;
	public GameObject song5;
	public GameObject song6;
	public GameObject song7;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		//scroll up
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))
		{
			songs.transform.Translate (0, 15, 0);
		}

		//scroll down
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow))
		{
			songs.transform.Translate (0, -15, 0);
		}

		//move bottom song to top
		if(song1.transform.position.y < 0)
			song1.transform.position = new Vector3 (15, 90, 0);
		if(song2.transform.position.y < 0)
			song2.transform.position = new Vector3 (15, 90, 0);
		if(song3.transform.position.y < 0)
			song3.transform.position = new Vector3 (15, 90, 0);
		if(song4.transform.position.y < 0)
			song4.transform.position = new Vector3 (15, 90, 0);
		if(song5.transform.position.y < 0)
			song5.transform.position = new Vector3 (15, 90, 0);
		if(song6.transform.position.y < 0)
			song6.transform.position = new Vector3 (15, 90, 0);
		if(song7.transform.position.y < 0)
			song7.transform.position = new Vector3 (15, 90, 0);

		//move top song to bottom
		if(song1.transform.position.y > 90)
			song1.transform.position = new Vector3 (15,0,0);
		if(song2.transform.position.y > 90)
			song2.transform.position = new Vector3 (15, 0, 0);
		if(song3.transform.position.y > 90)
			song3.transform.position = new Vector3 (15, 0, 0);
		if(song4.transform.position.y > 90)
			song4.transform.position = new Vector3 (15, 0, 0);
		if(song5.transform.position.y > 90)
			song5.transform.position = new Vector3 (15, 0, 0);
		if(song6.transform.position.y > 90)
			song6.transform.position = new Vector3 (15, 0, 0);
		if(song7.transform.position.y > 90)
			song7.transform.position = new Vector3 (15, 0, 0);

		//change positions y==90
		if(song1.transform.position.y == 90)
			song1.transform.position = new Vector3(15,90,0);
		if(song2.transform.position.y == 90)
			song2.transform.position = new Vector3(15,90,0);
		if(song3.transform.position.y == 90)
			song3.transform.position = new Vector3(15,90,0);
		if(song4.transform.position.y == 90)
			song4.transform.position = new Vector3(15,90,0);
		if(song5.transform.position.y == 90)
			song5.transform.position = new Vector3(15,90,0);
		if(song6.transform.position.y == 90)
			song6.transform.position = new Vector3(15,90,0);
		if(song7.transform.position.y == 90)
			song7.transform.position = new Vector3(15,90,0);

		//change positions y==75
		if(song1.transform.position.y == 75)
			song1.transform.position = new Vector3(10,75,0);
		if(song2.transform.position.y == 75)
			song2.transform.position = new Vector3(10,75,0);
		if(song3.transform.position.y == 75)
			song3.transform.position = new Vector3(10,75,0);
		if(song4.transform.position.y == 75)
			song4.transform.position = new Vector3(10,75,0);
		if(song5.transform.position.y == 75)
			song5.transform.position = new Vector3(10,75,0);
		if(song6.transform.position.y == 75)
			song6.transform.position = new Vector3(10,75,0);
		if(song7.transform.position.y == 75)
			song7.transform.position = new Vector3(10,75,0);

		//change positions y==60
		if(song1.transform.position.y == 60)
			song1.transform.position = new Vector3(5,60,0);
		if(song2.transform.position.y == 60)
			song2.transform.position = new Vector3(5,60,0);
		if(song3.transform.position.y == 60)
			song3.transform.position = new Vector3(5,60,0);
		if(song4.transform.position.y == 60)
			song4.transform.position = new Vector3(5,60,0);
		if(song5.transform.position.y == 60)
			song5.transform.position = new Vector3(5,60,0);
		if(song6.transform.position.y == 60)
			song6.transform.position = new Vector3(5,60,0);
		if(song7.transform.position.y == 60)
			song7.transform.position = new Vector3(5,60,0);

		//change positions y==45
		if(song1.transform.position.y == 45)
			song1.transform.position = new Vector3(0,45,0);
		if(song2.transform.position.y == 45)
			song2.transform.position = new Vector3(0,45,0);
		if(song3.transform.position.y == 45)
			song3.transform.position = new Vector3(0,45,0);
		if(song4.transform.position.y == 45)
			song4.transform.position = new Vector3(0,45,0);
		if(song5.transform.position.y == 45)
			song5.transform.position = new Vector3(0,45,0);
		if(song6.transform.position.y == 45)
			song6.transform.position = new Vector3(0,45,0);
		if(song7.transform.position.y == 45)
			song7.transform.position = new Vector3(0,45,0);

		//change positions y==30
		if(song1.transform.position.y == 30)
			song1.transform.position = new Vector3(5,30,0);
		if(song2.transform.position.y == 30)
			song2.transform.position = new Vector3(5,30,0);
		if(song3.transform.position.y == 30)
			song3.transform.position = new Vector3(5,30,0);
		if(song4.transform.position.y == 30)
			song4.transform.position = new Vector3(5,30,0);
		if(song5.transform.position.y == 30)
			song5.transform.position = new Vector3(5,30,0);
		if(song6.transform.position.y == 30)
			song6.transform.position = new Vector3(5,30,0);
		if(song7.transform.position.y == 30)
			song7.transform.position = new Vector3(5,30,0);
		
		//change positions y==15
		if(song1.transform.position.y == 15)
			song1.transform.position = new Vector3(10,15,0);
		if(song2.transform.position.y == 15)
			song2.transform.position = new Vector3(10,15,0);
		if(song3.transform.position.y == 15)
			song3.transform.position = new Vector3(10,15,0);
		if(song4.transform.position.y == 15)
			song4.transform.position = new Vector3(10,15,0);
		if(song5.transform.position.y == 15)
			song5.transform.position = new Vector3(10,15,0);
		if(song6.transform.position.y == 15)
			song6.transform.position = new Vector3(10,15,0);
		if(song7.transform.position.y == 15)
			song7.transform.position = new Vector3(10,15,0);
		
		//change positions y==0
		if(song1.transform.position.y == 0)
			song1.transform.position = new Vector3(15,0,0);
		if(song2.transform.position.y == 0)
			song2.transform.position = new Vector3(15,0,0);
		if(song3.transform.position.y == 0)
			song3.transform.position = new Vector3(15,0,0);
		if(song4.transform.position.y == 0)
			song4.transform.position = new Vector3(15,0,0);
		if(song5.transform.position.y == 0)
			song5.transform.position = new Vector3(15,0,0);
		if(song6.transform.position.y == 0)
			song6.transform.position = new Vector3(15,0,0);
		if(song7.transform.position.y == 0)
			song7.transform.position = new Vector3(15,0,0);

		//change rotation y==90
		if (song1.transform.position.y == 90)
			song1.transform.eulerAngles = new Vector3 (-60,0,0);
		if (song2.transform.position.y == 90)
			song2.transform.eulerAngles = new Vector3 (-60,0,0);
		if (song3.transform.position.y == 90)
			song3.transform.eulerAngles = new Vector3 (-60,0,0);
		if (song4.transform.position.y == 90)
			song4.transform.eulerAngles = new Vector3 (-60,0,0);
		if (song5.transform.position.y == 90)
			song5.transform.eulerAngles = new Vector3 (-60,0,0);
		if (song6.transform.position.y == 90)
			song6.transform.eulerAngles = new Vector3 (-60,0,0);
		if (song7.transform.position.y == 90)
			song7.transform.eulerAngles = new Vector3 (-60,0,0);
		
		//change rotation y==75
		if (song1.transform.position.y == 75)
			song1.transform.eulerAngles = new Vector3 (-70,0,0);
		if (song2.transform.position.y == 75)
			song2.transform.eulerAngles = new Vector3 (-70,0,0);
		if (song3.transform.position.y == 75)
			song3.transform.eulerAngles = new Vector3 (-70,0,0);
		if (song4.transform.position.y == 75)
			song4.transform.eulerAngles = new Vector3 (-70,0,0);
		if (song5.transform.position.y == 75)
			song5.transform.eulerAngles = new Vector3 (-70,0,0);
		if (song6.transform.position.y == 75)
			song6.transform.eulerAngles = new Vector3 (-70,0,0);
		if (song7.transform.position.y == 75)
			song7.transform.eulerAngles = new Vector3 (-70,0,0);
		
		//change rotation y==60
		if (song1.transform.position.y == 60)
			song1.transform.eulerAngles = new Vector3 (-80,0,0);
		if (song2.transform.position.y == 60)
			song2.transform.eulerAngles = new Vector3 (-80,0,0);
		if (song3.transform.position.y == 60)
			song3.transform.eulerAngles = new Vector3 (-80,0,0);
		if (song4.transform.position.y == 60)
			song4.transform.eulerAngles = new Vector3 (-80,0,0);
		if (song5.transform.position.y == 60)
			song5.transform.eulerAngles = new Vector3 (-80,0,0);
		if (song6.transform.position.y == 60)
			song6.transform.eulerAngles = new Vector3 (-80,0,0);
		if (song7.transform.position.y == 60)
			song7.transform.eulerAngles = new Vector3 (-80,0,0);
		
		//change rotation y==45
		if (song1.transform.position.y == 45)
			song1.transform.eulerAngles = new Vector3 (-90,0,0);
		if (song2.transform.position.y == 45)
			song2.transform.eulerAngles = new Vector3 (-90,0,0);
		if (song3.transform.position.y == 45)
			song3.transform.eulerAngles = new Vector3 (-90,0,0);
		if (song4.transform.position.y == 45)
			song4.transform.eulerAngles = new Vector3 (-90,0,0);
		if (song5.transform.position.y == 45)
			song5.transform.eulerAngles = new Vector3 (-90,0,0);
		if (song6.transform.position.y == 45)
			song6.transform.eulerAngles = new Vector3 (-90,0,0);
		if (song7.transform.position.y == 45)
			song7.transform.eulerAngles = new Vector3 (-90,0,0);
		
		//change rotation y==30
		if (song1.transform.position.y == 30)
			song1.transform.eulerAngles = new Vector3 (-100,0,0);
		if (song2.transform.position.y == 30)
			song2.transform.eulerAngles = new Vector3 (-100,0,0);
		if (song3.transform.position.y == 30)
			song3.transform.eulerAngles = new Vector3 (-100,0,0);
		if (song4.transform.position.y == 30)
			song4.transform.eulerAngles = new Vector3 (-100,0,0);
		if (song5.transform.position.y == 30)
			song5.transform.eulerAngles = new Vector3 (-100,0,0);
		if (song6.transform.position.y == 30)
			song6.transform.eulerAngles = new Vector3 (-100,0,0);
		if (song7.transform.position.y == 30)
			song7.transform.eulerAngles = new Vector3 (-100,0,0);
		
		//change rotation y==15
		if (song1.transform.position.y == 15)
			song1.transform.eulerAngles = new Vector3 (-110,0,0);
		if (song2.transform.position.y == 15)
			song2.transform.eulerAngles = new Vector3 (-110,0,0);
		if (song3.transform.position.y == 15)
			song3.transform.eulerAngles = new Vector3 (-110,0,0);
		if (song4.transform.position.y == 15)
			song4.transform.eulerAngles = new Vector3 (-110,0,0);
		if (song5.transform.position.y == 15)
			song5.transform.eulerAngles = new Vector3 (-110,0,0);
		if (song6.transform.position.y == 15)
			song6.transform.eulerAngles = new Vector3 (-110,0,0);
		if (song7.transform.position.y == 15)
			song7.transform.eulerAngles = new Vector3 (-110,0,0);
		
		//change rotation y==0
		if (song1.transform.position.y == 0)
			song1.transform.eulerAngles = new Vector3 (-120,0,0);
		if (song2.transform.position.y == 0)
			song2.transform.eulerAngles = new Vector3 (-120,0,0);
		if (song3.transform.position.y == 0)
			song3.transform.eulerAngles = new Vector3 (-120,0,0);
		if (song4.transform.position.y == 0)
			song4.transform.eulerAngles = new Vector3 (-120,0,0);
		if (song5.transform.position.y == 0)
			song5.transform.eulerAngles = new Vector3 (-120,0,0);
		if (song6.transform.position.y == 0)
			song6.transform.eulerAngles = new Vector3 (-120,0,0);
		if (song7.transform.position.y == 0)
			song7.transform.eulerAngles = new Vector3 (-120,0,0);

	}
	
}
