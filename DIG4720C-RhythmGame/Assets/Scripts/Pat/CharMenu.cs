
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharMenu : MonoBehaviour {

    #region vars
    public GameObject[] Players;
    public static GameObject Player1;
    public static GameObject Player2;
    Quaternion rot = new Quaternion(0, 165, 0,0);
    public Transform P1;
    public Transform P2;
    public Vector3 P2Spot = new Vector3(16.92f, 226.41f, 5.08f);
    public Vector3 P1Spot = new Vector3(1.85f, 226.41f, 5.08f);
    public static bool first = true;
    public PauseMenu Pause;
    private Manager mngr;
    #endregion

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Players[i] = GameObject.Find("Players").transform.GetChild(i).gameObject;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CharSelect") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MultiplayerCharSelect"))
        {
            P1 = GameObject.Find("P1").transform;
            if (GameObject.Find("P2") != null)
            {
                P2 = GameObject.Find("P2").transform;

                P2.gameObject.SetActive(false);
            }
            PlayerButton(0);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MultiPlayer"))
        {
            P1 = GameObject.Find("P1").transform;
            P2 = GameObject.Find("P2").transform;
            PlayerButton(PlayerPrefs.GetInt("Player1Pref"));
            Player2Button(PlayerPrefs.GetInt("Player2Pref"));
            Player1.transform.SetParent(P1);
            Player2.transform.SetParent(P2);
            Player1.SetActive(true);
            Player2.SetActive(true);
            P1Spot = new Vector3(1.85f, 226.41f, 5.08f);
            P2Spot = new Vector3(32f, 226.41f, 5.08f);
            P1.position = P1Spot;
            P2.position = P2Spot;
            mngr = GameObject.Find("Manager").GetComponent<Manager>();
            mngr.BG.material.SetTexture("_MainTex",mngr.BGs[PlayerPrefs.GetInt("StagePref")]);

        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SinglePlayer"))
        {
            mngr = GameObject.Find("Manager").GetComponent<Manager>();

            P1 = GameObject.Find("P1").transform;
            P2 = GameObject.Find("P2").transform;
            PlayerButton(PlayerPrefs.GetInt("Player1Pref"));
            if (first)
            {
                PlayerPrefs.SetInt("Player2Pref", PlayerPrefs.GetInt("Player1Pref") + 1);

                if (PlayerPrefs.GetInt("Player2Pref") == 4)
                {
                    PlayerPrefs.SetInt("Player2Pref", 0);
                }
                Player2Button(PlayerPrefs.GetInt("Player2Pref"));
                first = false;
            }
            else
            {
                Player2Button(PlayerPrefs.GetInt("Player2Pref"));
            }
            Player1.transform.SetParent(P1);
            Player2.transform.SetParent(P2);
            Player1.SetActive(true);
            Player2.SetActive(true);
            P1Spot = new Vector3(1.85f, 226.41f, 5.08f);
            P2Spot = new Vector3(32f, 226.41f, 5.08f);
            P1.position = P1Spot;
            P2.position = P2Spot;
            mngr.isAI = true;
            mngr.BG.material.SetTexture("_MainTex", mngr.BGs[PlayerPrefs.GetInt("Player2Pref")]);

        }
    }

    //Load Singleplayer
    public void SinglePlayerStart()
    {
        SceneManager.LoadScene(3);
    }

    //Load Multiplayer
    public void MultiPlayerStart()
    {
        SceneManager.LoadScene(5);
    }

    //Load MainMenu
    public void Backbutton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    //sets up first stage of the game 
    public void togglefirst()
    {
        first = true;
        PlayerPrefs.SetInt("AI", 75);
        if(Pause != null)
        Pause.Reset();
    }

    //go through players set correct active and the rest not, assign to player pref for multiscene managment PLAYER1
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

    //go through players set correct active and the rest not, assign to player pref for multiscene managment PLAYER2
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

    // set AI 
    public void AI(int i)
    {
        Player2 = Players[i];
        if (PlayerPrefs.GetInt("Player2Pref") != i)
        {
            PlayerPrefs.SetInt("Player2Pref", i);
        }
        SinglePlayerStart();
    }

    // Player2 cannot choose who Player1 is.
    public void disableBut()
    {
        P2.GetChild(PlayerPrefs.GetInt("Player1Pref")).gameObject.GetComponent<Button>().enabled = false;     
    }

}
