using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//moving halo
		if (Input.GetKeyDown (KeyCode.W)) 
			transform.Translate (0,14,0);

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
			transform.Translate (0,14,0);

		if (Input.GetKeyDown (KeyCode.A)) 
			transform.Translate (-54,0,0);

		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			transform.Translate (-54,0,0);

		if (Input.GetKeyDown (KeyCode.S)) 
			transform.Translate (0,-14,0);

		if (Input.GetKeyDown (KeyCode.DownArrow)) 
			transform.Translate (0,-14,0);
		
		if (Input.GetKeyDown (KeyCode.D)) 
			transform.Translate (54,0,0);

		if (Input.GetKeyDown (KeyCode.RightArrow))
			transform.Translate (54,0,0);

		//hitting right edge 1st row
		if(transform.position.x == 76.9f && transform.position.y == 21.3f)
			transform.position = new Vector3 (-31.1f,21.3f,0.3695488f);
		//hitting left edge 1st row
		if(transform.position.x == -85.1f && transform.position.y == 21.3f)
			transform.position = new Vector3 (22.9f,21.3f,0.3695488f);

		//hitting right edge 2nd row
		if(transform.position.x == 76.9f && transform.position.y == 7.299999f)
			transform.position = new Vector3 (-31.1f,7.299999f,0.3695488f);
		//hitting left edge 2nd row
		if(transform.position.x == -85.1f && transform.position.y == 7.299999f)
			transform.position = new Vector3 (22.9f,7.299999f,0.3695488f);
		
		//hitting top edge 1st column
		if(transform.position.y == 35.3f && transform.position.x == -31.1f)
			transform.position = new Vector3 (-31.1f,7.299999f,0.3695488f);
		//hitting bottom edge 1st column
		if(transform.position.y == -6.700001f && transform.position.x == -31.1f)
			transform.position = new Vector3 (-31.1f,21.3f,0.3695488f);

		//hitting top edge 2nd column DONT WORK
		//if(transform.position.y == 35.3f && transform.position.x == -4.1f)
		//	transform.position = new Vector3 (-4.1f,7.299999f,0.3695488f);
		//hitting bottom edge 2nd column DONT WORK
		//if(transform.position.y == -6.700001f && transform.position.x == -4.1f)
		//	transform.position = new Vector3 (-4.1f,21.3f,0.3695488f);

		//hitting top edge 3rd column
		if(transform.position.y == 35.3f && transform.position.x == 22.9f)
			transform.position = new Vector3 (22.9f,7.299999f,0.3695488f);
		//hitting bottom edge 3rd column
		if(transform.position.y == -6.700001f && transform.position.x == 22.9f)
			transform.position = new Vector3 (22.9f,21.3f,0.3695488f);
	}
}
