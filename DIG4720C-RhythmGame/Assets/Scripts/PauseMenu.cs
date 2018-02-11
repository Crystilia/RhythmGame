using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

    public static bool Paused = false;
    public GameObject MenuHUD;
   
	// Use this for initialization
	void Start () {
        MenuHUD = transform.GetChild(0).gameObject;
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
        SceneManager.LoadScene(0);
    }

    void Pause()
    {
        MenuHUD.SetActive(true);
        Paused = true;
        Time.timeScale = 0f;
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
