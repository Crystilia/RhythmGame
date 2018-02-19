using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMenu : MonoBehaviour {
    public GameObject[] Players;
    public static GameObject Player;
    Quaternion rot = new Quaternion(0, 165, 0,0);
    private void Start()
    {
            Players[0] = GameObject.Find("Player1");
            Players[1] = GameObject.Find("Player2");
            Players[2] = GameObject.Find("Player3");
            Players[3] = GameObject.Find("Player4");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CharSelect") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MultiplayerCharSelect"))
        {
            PlayerButton(0);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SinglePlayer"))
        {
            PlayerButton(PlayerPrefs.GetInt("P"));
        }
    }
    public void Char1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Backbutton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayerButton(int i)
    {
        if (Player != null)
        {
            rot = Player.transform.rotation;
        }
        Player = Players[i];

        for (int k = 0; k < Players.Length; k++)
        {

            Players[k].SetActive(false);
        }
        Player.SetActive(true);
        Player.transform.rotation = rot;

        if (PlayerPrefs.GetInt("P") != i)
        {
            PlayerPrefs.SetInt("P", i);
        }
    }
}
