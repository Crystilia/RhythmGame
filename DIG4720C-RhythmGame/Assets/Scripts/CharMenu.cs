
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMenu : MonoBehaviour {
    public GameObject[] Players;
    public static GameObject Player1;
    public static GameObject Player2;
    Quaternion rot = new Quaternion(0, 165, 0,0);
    public Transform P1;
    public Transform P2;

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
            PlayerButton(PlayerPrefs.GetInt("Player1Pref"));
            P1 = GameObject.Find("P1").transform;
            Player1.transform.SetParent(P1);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MultiPlayer"))
        {
            P1 = GameObject.Find("P1").transform;
            P2 = GameObject.Find("P2").transform;
            PlayerButton(PlayerPrefs.GetInt("Player1Pref"));
            Player2Button(PlayerPrefs.GetInt("Player2Pref"));
            Player1.transform.SetParent(P1);
            Player2.transform.SetParent(P2);

        }
    }
    public void SinglePlayerStart()
    {
        SceneManager.LoadScene(3);
    }
    public void MultiPlayerStart()
    {
        SceneManager.LoadScene(4);
    }
    public void Backbutton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayerButton(int i)
    {
        if (Player1 != null)
        {
            rot = Player1.transform.rotation;
        }
        Player1 = Players[i];

        for (int k = 0; k < Players.Length; k++)
        {
            if (Players[k].activeInHierarchy)
            {
                Players[k].SetActive(false);
            }
        }
        Player1.SetActive(true);
        Player1.transform.rotation = rot;

        if (PlayerPrefs.GetInt("Player1Pref") != i)
        {
            PlayerPrefs.SetInt("Player1Pref", i);
        }
    }
    public void Player2Button(int i)
    {
        if (Player2 != null)
        {
            rot = Player2.transform.rotation;
        }
        Player2 = Players[i];

        for (int k = 0; k < Players.Length; k++)
        {

            Players[k].SetActive(false);
        }
        Player2.SetActive(true);
        Player2.transform.rotation = rot;

        if (PlayerPrefs.GetInt("Player2Pref") != i)
        {
            PlayerPrefs.SetInt("Player2Pref", i);
        }
    }
}
