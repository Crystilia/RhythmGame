using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMenu : MonoBehaviour {
    public GameObject[] Players;
    public static GameObject Player;
    private void Start()
    {
        Players[0] = GameObject.Find("PatsCharTest").gameObject;
        Players[1] = GameObject.Find("player2").gameObject;
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
    }
    public void p2button(int i)
    {
        Player = Players[i];
    }
}
