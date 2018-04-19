using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class ChooseStage : MonoBehaviour {

	public GameObject pick;
	public GameObject stage1;
	public GameObject stage2;
	public GameObject stage3;
	public GameObject stage4;
    private AM AudioManager;
    public bool stagesel = true;
    public EventSystem em;
    public GameObject but;

    private bool toggleNoise = true;
     void Start()
    {
        AudioManager = GameObject.Find("AM").GetComponent<AM>();
		stage1.gameObject.SetActive (true);
		stage2.gameObject.SetActive (false);
		stage3.gameObject.SetActive (false);
		stage4.gameObject.SetActive (false);
	}


    public void UISfx(int i)
    {
        if (AM.on)
            AudioManager.PlaySfx(3, i, 0.5f);
        else
        {
            AM.on = true;
        }
    }
    // Update is called once per frame
    void Update () {
        //move up
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && stagesel)
        {
            pick.transform.Translate(0, 0, 100);
            if (toggleNoise)
            {
                UISfx(0);
                toggleNoise = false;
            }
            else
            {
                UISfx(1);
                toggleNoise = true;
            }
        }


        //move down
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && stagesel)
        {
            pick.transform.Translate(0, 0, -100);
            if (toggleNoise)
            {
                UISfx(0);
                toggleNoise = false;
            }
            else
            {
                UISfx(1);
                toggleNoise = true;
            }
        }


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
		if(Input.GetKeyDown(KeyCode.Return) && stagesel)
		{
                UISfx(2);
            //scene stage 1
            if (pick.transform.position.y >= 300 && pick.transform.position.y <= 310)
            PlayerPrefs.SetInt("StagePref", 0);
            SceneManager.LoadScene(4);
            //scene stage 2
            if (pick.transform.position.y >= 200 && pick.transform.position.y <= 210)
            PlayerPrefs.SetInt("StagePref", 2);

            //scene stage 3
            if (pick.transform.position.y >= 100 && pick.transform.position.y <= 110)
            PlayerPrefs.SetInt("StagePref", 3);

            //scene stage 4
            if (pick.transform.position.y >= 0 && pick.transform.position.y <= 10)
            PlayerPrefs.SetInt("StagePref", 1);

            SceneManager.LoadScene(4);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            stagesel = true;
            PauseMenu.Paused = false;
            if (toggleNoise)
            {
                UISfx(0);
                toggleNoise = false;
            }
            else
            {
                UISfx(1);
                toggleNoise = true;
            }
            em.SetSelectedGameObject(null);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            stagesel = false;
            PauseMenu.Paused = false;
            if (toggleNoise)
            {
                UISfx(0);
                toggleNoise = false;
            }
            else
            {
                UISfx(1);
                toggleNoise = true;
            }
            em.SetSelectedGameObject(but);
        }
    }
}
