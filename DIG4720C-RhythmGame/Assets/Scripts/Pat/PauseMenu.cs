using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

    static public bool Paused = false;
    public GameObject MenuHUD;
    private Manager mngr;
    static public int stage = 3;


    // Use this for initialization
    void Start() {
        MenuHUD = transform.GetChild(0).gameObject;
        mngr = GetComponent<Manager>();
        if(stage > 1)
        {
            Manager.BossDmg += 0.1f;
        }
    }

    //resets the game back to level 1
    public void Reset()
    {
        stage = 1;
        Manager.BossDmg = 0;
        mngr.Stage[0].gameObject.SetActive(true);
        mngr.Stage[1].gameObject.SetActive(false);
    }

    //resume the game
    public void Resume()
    {
        MenuHUD.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        mngr.AudioManager.soundSrc[0].UnPause();
    }


    // return to the mainmenu
    public void QuitGame()
    {
        Paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    //update players based on stage
    public void Progress()
    {
        if (stage != 3)
        {
            Paused = false;
            Time.timeScale = 1f;
            stage++;

            PlayerPrefs.SetInt("AI", (PlayerPrefs.GetInt("AI") + 10));

            PlayerPrefs.SetInt("Player2Pref", (PlayerPrefs.GetInt("Player2Pref") + 1));

            if (PlayerPrefs.GetInt("Player2Pref") == PlayerPrefs.GetInt("Player1Pref"))
            {
                PlayerPrefs.SetInt("Player2Pref", (PlayerPrefs.GetInt("Player2Pref") + 1));
            }
            if (PlayerPrefs.GetInt("Player2Pref") == 4)
            {
                PlayerPrefs.SetInt("Player2Pref", 0);
            }
            if (PlayerPrefs.GetInt("Player2Pref") == PlayerPrefs.GetInt("Player1Pref"))
            {
                PlayerPrefs.SetInt("Player2Pref", (PlayerPrefs.GetInt("Player2Pref") + 1));
            }
            SceneManager.LoadScene(3);
        }
        else if (stage == 3)
        {
            Paused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
    }


    //pause the game
    void Pause()
    {
        MenuHUD.SetActive(true);
        Paused = true;
        Time.timeScale = 0f;
        mngr.AudioManager.soundSrc[0].Pause();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P) && mngr.canB == true)
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
