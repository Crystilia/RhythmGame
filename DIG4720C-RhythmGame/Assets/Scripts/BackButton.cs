using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	public void ToStageSelect()
	{
		SceneManager.LoadScene("StageSelection");
	}

	public void ToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
