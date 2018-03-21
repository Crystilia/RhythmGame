using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseStage : MonoBehaviour {

	public GameObject pick;
	public GameObject stage1;
	public GameObject stage2;
	public GameObject stage3;
	public GameObject stage4;


	// Use this for initialization
	void Start () {
		stage1.gameObject.SetActive (true);
		stage2.gameObject.SetActive (false);
		stage3.gameObject.SetActive (false);
		stage4.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//move up
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))
			pick.transform.Translate (0,0,100);
		
		//move down
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow))
			pick.transform.Translate (0,0,-100);


		//too far up
		if(pick.transform.position.x == 780 && pick.transform.position.y > 306)
			pick.transform.position = new Vector3 (780,5,1);
		
		//too far down
		if(pick.transform.position.x == 780 && pick.transform.position.y < 4)
			pick.transform.position = new Vector3 (780,305,1);

		//stage 1
		if (pick.transform.position.y >= 300 && pick.transform.position.y <= 310)
		{
			stage1.gameObject.SetActive (true);
			stage2.gameObject.SetActive (false);
			stage3.gameObject.SetActive (false);
			stage4.gameObject.SetActive (false);
		}
		//stage 2
		if (pick.transform.position.y >= 200 && pick.transform.position.y <= 210) 
		{
			stage1.gameObject.SetActive (false);
			stage2.gameObject.SetActive (true);
			stage3.gameObject.SetActive (false);
			stage4.gameObject.SetActive (false);
		}
		//stage 3
		if (pick.transform.position.y >= 100 && pick.transform.position.y <= 110) 
		{
			stage1.gameObject.SetActive (false);
			stage2.gameObject.SetActive (false);
			stage3.gameObject.SetActive (true);
			stage4.gameObject.SetActive (false);
		}
		//stage 4
		if (pick.transform.position.y >= 0 && pick.transform.position.y <= 10) 
		{
			stage1.gameObject.SetActive (false);
			stage2.gameObject.SetActive (false);
			stage3.gameObject.SetActive (false);
			stage4.gameObject.SetActive (true);
		}

		//pick a stage
		if(Input.GetKeyDown(KeyCode.Return))
		{
			//scene stage 1
			if(pick.transform.position.y >= 300 && pick.transform.position.y <= 310)
				SceneManager.LoadScene("Stage1");
			//scene stage 2
			if(pick.transform.position.y >= 200 && pick.transform.position.y <= 210)
				SceneManager.LoadScene("Stage2");
			//scene stage 3
			if(pick.transform.position.y >= 100 && pick.transform.position.y <= 110)
				SceneManager.LoadScene("Stage3");
			//scene stage 4
			if(pick.transform.position.y >= 0 && pick.transform.position.y <= 10)
				SceneManager.LoadScene("Stage4");
		}
	}
}
