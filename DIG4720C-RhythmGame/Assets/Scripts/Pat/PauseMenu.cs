using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

    public static bool Paused = false;
    public GameObject MenuHUD;
    private Manager mngr;
    public int stage = 1;
    // Use this for initialization
    void Start () {
        MenuHUD = transform.GetChild(0).gameObject;
        mngr = GetComponent<Manager>();
    }

    public void Reset()
    {
        stage = 1;
    }
    public void Resume()
    {
        MenuHUD.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }



    public void QuitGame()
    {
        Paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

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
    }
    void Pause()
    {
        MenuHUD.SetActive(true);
        Paused = true;
        Time.timeScale = 0f;
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
