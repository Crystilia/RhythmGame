using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

    public static bool Paused = false;
    public GameObject MenuHUD;
	// Use this for initialization
	void Start () {
	}

    public void Resume()
    {
        MenuHUD.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void LoadMenu()
    {

    }

    public void QuitGame()
    {
        Paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start_Menu");
    }

    void Pause()
    {
        MenuHUD.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
           // Paused == true ? Resume() : Pause();
           if(Paused)
            {
                Resume();
            }
           else
            {
                Pause();
            }
        }
	}
}
