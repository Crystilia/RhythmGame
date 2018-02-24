using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Manager : MonoBehaviour {

    private Image P1HP;
    private Image P1PU;
    float P1CurrentHP = 1;
    float P1CurrentPU = 0;
    private Image P2HP;
    private Image P2PU;
    float P2CurrentHP = 1;
    float P2CurrentPU = 0;
    bool p1canUseSpecial = false;
    bool p2canUseSpecial = false;
    public GameObject gameover;
    public GameObject gameoverMenu;
    public bool canB = true;
    Animator player1;
    Animator player2;
    bool P1Drain;
    bool P2Drain;
    float CurrentP1DMG = 200;
    int P1DMG = 200;
    int P2DMG = 200;
    float CurrentP2DMG = 200;
    int P1Uses = 1;
    int P2Uses = 1;
    // Use this for initialization
    void Start ()
    {
        player1 = GameObject.Find("P1").GetComponentInChildren<Animator>();
        P1HP = GameObject.Find("P1HP").GetComponent<Image>();
        P1PU = GameObject.Find("P1PU").GetComponent<Image>();
        P1HP.fillAmount = P1CurrentHP;
        P1PU.fillAmount = P1CurrentPU;
        P2HP = GameObject.Find("P2HP").GetComponent<Image>();
        P2PU = GameObject.Find("P2PU").GetComponent<Image>();
        P2HP.fillAmount = P2CurrentHP;
        P2PU.fillAmount = P2CurrentPU;
        if (gameover != null)
        {
            gameover.SetActive(false);
            gameoverMenu.SetActive(false);
        }
    }

    public void LowerHP(bool P, float Dmg)
    {   if (P)
        {
            if (P1CurrentHP > 0)
            {
                P1CurrentHP = P1CurrentHP - Dmg;
                P1HP.fillAmount = P1CurrentHP;
            }
            else
            {
                P1CurrentHP = 0;
                P1HP.fillAmount = P1CurrentHP;
                //put u lose stuff here;
                Time.timeScale = 0.0f;
                gameover.SetActive(true);
                gameoverMenu.SetActive(true);
                gameover.GetComponent<TextMeshProUGUI>().text = "P2 Wins!";
                canB = false;
            }
        }
        if (!P)
        {
            if (P2CurrentHP > 0)
            {
                P2CurrentHP = P2CurrentHP - Dmg;
                P2HP.fillAmount = P2CurrentHP;
            }
            else
            {
                P2CurrentHP = 0;
                P2HP.fillAmount = P2CurrentHP;
                //put u lose stuff here;
                Time.timeScale = 0.0f;
                gameover.SetActive(true);
                gameoverMenu.SetActive(true);
                gameover.GetComponent<TextMeshProUGUI>().text = "P1 Wins!";
                canB = false;
            }
        }
    }

    public void RaisePU(bool P)
    {
        if (P)
        {
            if (P1PU.fillAmount < 1f)
            {
                P1CurrentPU = P1CurrentPU + 0.1f;
                P1PU.fillAmount = P1CurrentPU;
            }
            else if (P1PU.fillAmount >= 1f)
            {
                P1CurrentPU = 1f;
                p1canUseSpecial = true;
                P1PU.fillAmount = P1CurrentPU;
                P1PU.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        if (!P)
        {
            if (P2PU.fillAmount < 1f)
            {
                P2CurrentPU = P2CurrentPU + 0.1f;
                P2PU.fillAmount = P2CurrentPU;
            }
            else if (P2PU.fillAmount >= 1f)
            {
                P2CurrentPU = 1f;
                p2canUseSpecial = true;
                P2PU.fillAmount = P2CurrentPU;
                P2PU.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }

    public void MaxPU(bool P)
    {
        if (P)
        {
            P1CurrentPU = 1f;
            RaisePU(true);
        }
        if (!P)
        {
            P2CurrentPU = 1f;
            RaisePU(false);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartATK()
    {
        //player1
        if (p1canUseSpecial && Input.GetKeyDown(KeyCode.Space))
        {
            P1PU.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            P1Drain = true;
            P1DMG = (200 / P1Uses);
            P1Uses ++;
}
        if (P1Drain)
        {
            // P1PU.fillAmount = (P1CurrentPU - (0.1f * Time.deltaTime));
            P1DMG -= 1;
            CurrentP1DMG = Mathf.Clamp01((P1DMG / 200f));
            P1PU.fillAmount = CurrentP1DMG;
            P1CurrentPU = P1PU.fillAmount;
            Debug.Log(CurrentP1DMG);

        }
        if (p1canUseSpecial && Input.GetKeyUp(KeyCode.Space))
        {
            P1Drain = false;
            player1.SetInteger("AnimState", 1);
            LowerHP(false, CurrentP1DMG);
            P1CurrentHP = P1CurrentHP + CurrentP1DMG;
            P1HP.fillAmount = P1CurrentHP;
            P1CurrentPU = 0;
            CurrentP1DMG = 0;
            P1PU.fillAmount = P1CurrentPU;
            p1canUseSpecial = false;
            P1PU.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        }
        //player2
        if (p2canUseSpecial && Input.GetKeyDown(KeyCode.Space))
        {
            P2PU.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            P2Drain = true;
            P2DMG = (200 / P2Uses);
            P2Uses++;
        }
        if (P2Drain)
        {
            P2DMG -= 1;
            CurrentP2DMG = Mathf.Clamp01((P2DMG / 200f));
            P2PU.fillAmount = CurrentP2DMG;
            P2CurrentPU = P2PU.fillAmount;
        }
        if (p2canUseSpecial && Input.GetKeyUp(KeyCode.Space))
        {
            P2Drain = false;
            player2.SetInteger("AnimState", 1);
            LowerHP(false, CurrentP1DMG);
            P2CurrentHP = P2CurrentHP + CurrentP2DMG;
            P2HP.fillAmount = P2CurrentHP;
            P2CurrentPU = 0;
            CurrentP2DMG = 0;
            P2PU.fillAmount = P2CurrentPU;
            p2canUseSpecial = false;
            P2PU.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        }
    }
    // Update is called once per frame
    void Update ()
    {
        StartATK();

    }
}
