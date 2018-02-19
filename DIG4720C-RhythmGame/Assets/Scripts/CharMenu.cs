
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
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MultiPlayer"))
        {
            PlayerButton(PlayerPrefs.GetInt("P"));
            Player2Button(PlayerPrefs.GetInt("P2"));
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
    public void Player2Button(int i)
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

        if (PlayerPrefs.GetInt("P2") != i)
        {
            PlayerPrefs.SetInt("P2", i);
        }
    }
}
