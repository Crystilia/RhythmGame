using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChosen : MonoBehaviour {

	void Update ()
	//public void LoadMap() 
	{ 
		if (Input.GetKeyDown (KeyCode.Return))
		{
			//load map 1
			if (transform.position.x == -31.1f && transform.position.y == 21.3f)
				SceneManager.LoadScene(1);

			//load map 2 DONT WORK
			//if (transform.position.x == -4.1f && transform.position.y == 21.3f)
			//	SceneManager.LoadScene(2);

			//load map 3
			if (transform.position.x == 22.9f && transform.position.y == 21.3f)
				SceneManager.LoadScene(3);

			//load map 4
			if (transform.position.x == -31.1f && transform.position.y == 7.299999f)
				SceneManager.LoadScene(4);

			//load map 5 DONT WORK
			//if (transform.position.x == -4.1f && transform.position.y == 7.299999f)
			//	SceneManager.LoadScene(5);

			//load map 6
			if (transform.position.x == 22.9f && transform.position.y == 7.299999f)
				SceneManager.LoadScene(6);
		}
	}
}
