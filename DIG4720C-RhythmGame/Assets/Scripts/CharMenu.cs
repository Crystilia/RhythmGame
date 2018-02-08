using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMenu : MonoBehaviour {
    public GameObject[] Players;
    public static GameObject Player;
    public Transform PlayerParent;
    private void Start()
    {
      
        //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CharSelect"))
       // {
            Players[0] = GameObject.Find("player1");
            Players[1] = GameObject.Find("player2");
            Players[2] = GameObject.Find("player3");
            Players[3] = GameObject.Find("player4");
           // PlayerParent = GameObject.Find("Player").transform;
        //}
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Pats_Playground"))
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
        Player = Players[i];
        for (int k = 0; k < Players.Length; k++)
        {
            Players[k].SetActive(false);
        }
        Player.SetActive(true);
        //  PlayerParent.DetachChildren();
        // Player.transform.SetParent(PlayerParent);
        if (PlayerPrefs.GetInt("P") != i)
        {
            PlayerPrefs.SetInt("P", i);
            Debug.Log(PlayerPrefs.GetInt("P"));
        }
    }
}
