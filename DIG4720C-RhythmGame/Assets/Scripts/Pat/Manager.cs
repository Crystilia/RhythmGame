using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class Manager : MonoBehaviour
{
    private Song_Generator SG;
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
    float P1atkTime;
    float P2atkTime;
    bool P1Drain;
    bool P2Drain;
    float CurrentP1DMG = 200;
    int P1DMG = 200;
    int P2DMG = 200;
    float CurrentP2DMG = 200;
    int P1Uses = 1;
    int P2Uses = 1;
    public GameObject P1ATK;
    public GameObject P1LH;
    public GameObject P1;
    public GameObject P2;
    float P1AtkSpeed = 15;
    public AM AudioManager;
    // Use this for initialization
    void Start()
    {
        SG = GameObject.Find("SongManager").GetComponent<Song_Generator>();
        AudioManager = GameObject.Find("AM").GetComponent<AM>();
        player1 = GameObject.Find("P1").GetComponentInChildren<Animator>();
        player2 = GameObject.Find("P2").GetComponentInChildren<Animator>();
        UpdateAnimClipTimes();
        P1HP = GameObject.Find("P1HP").GetComponent<Image>();
        P1PU = GameObject.Find("P1PU").GetComponent<Image>();
        P1HP.fillAmount = P1CurrentHP;
        P1PU.fillAmount = P1CurrentPU;
        P2HP = GameObject.Find("P2HP").GetComponent<Image>();
        P2PU = GameObject.Find("P2PU").GetComponent<Image>();
        P2HP.fillAmount = P2CurrentHP;
        P2PU.fillAmount = P2CurrentPU;
        player1.SetInteger("AnimState", 1);
        player2.SetInteger("AnimState", 1);
        if (gameover != null)
        {
            gameover.SetActive(false);
            gameoverMenu.SetActive(false);
        }
    }

    public void LowerHP(bool P, float Dmg)
    {
        if (P)
        {
            if (P1CurrentHP > 0)
            {
                P1CurrentHP = P1CurrentHP - Dmg;
                P1HP.fillAmount = P1CurrentHP;
                AudioManager.soundSrc[3].PlayOneShot(AudioManager.sfx[2]);
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
            AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[3]);
        }
        if (!P)
        {
            P2CurrentPU = 1f;
            RaisePU(false);
            AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[3]);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SongDur()
    {
        SG.MaxNotes--;
    }

    public void StartATK()
    {
        if (SG.MaxNotes == 0 && P1CurrentHP > P2CurrentHP)
        {
            Time.timeScale = 0.0f;
            gameover.SetActive(true);
            gameoverMenu.SetActive(true);
            gameover.GetComponent<TextMeshProUGUI>().text = "P1 Wins!";
            canB = false;
        }
        else if (SG.MaxNotes == 0 && P1CurrentHP < P2CurrentHP)
        {
            Time.timeScale = 0.0f;
            gameover.SetActive(true);
            gameoverMenu.SetActive(true);
            gameover.GetComponent<TextMeshProUGUI>().text = "P2 Wins!";
            canB = false;
        }
        else if (SG.MaxNotes == 0)
        {
            Time.timeScale = 0.0f;
            gameover.SetActive(true);
            gameoverMenu.SetActive(true);
            gameover.GetComponent<TextMeshProUGUI>().text = "Tie!";
            canB = false;
        }
        //player1
        if (p1canUseSpecial && Input.GetKeyDown(KeyCode.Space))
        {
            P1PU.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            P1Drain = true;
            P1DMG = (200 / P1Uses);
            P1Uses++;
        }
        if (P1Drain)
        {
            // P1PU.fillAmount = (P1CurrentPU - (0.1f * Time.deltaTime));
            P1DMG -= 1;
            CurrentP1DMG = Mathf.Clamp01((P1DMG / 200f));
            P1PU.fillAmount = CurrentP1DMG;
            P1CurrentPU = P1PU.fillAmount;

        }
        if (p1canUseSpecial && Input.GetKeyUp(KeyCode.Space))
        {
            P1Drain = false;
            AttackAnim(true, CurrentP1DMG);
            P1CurrentHP = P1CurrentHP + CurrentP1DMG;
            P1HP.fillAmount = P1CurrentHP;
            P1CurrentPU = 0;
            P1PU.fillAmount = P1CurrentPU;
            p1canUseSpecial = false;
            P1PU.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            CurrentP1DMG = 0;
            AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[0]);
        }
        //player2
        if (p2canUseSpecial && Input.GetKeyDown(KeyCode.B))
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
        if (p2canUseSpecial && Input.GetKeyUp(KeyCode.B))
        {
            P2Drain = false;
            AttackAnim(false, CurrentP2DMG);
            LowerHP(false, CurrentP1DMG);
            P2CurrentHP = P2CurrentHP + CurrentP2DMG;
            P2HP.fillAmount = P2CurrentHP;
            P2CurrentPU = 0;
            CurrentP2DMG = 0;
            P2PU.fillAmount = P2CurrentPU;
            p2canUseSpecial = false;
            P2PU.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[1]);
        }
    }

    void AttackAnim(bool P, float DMG)
    {
        if (P)
        {
            player1.SetInteger("AnimState", 2);
            P1ATK.SetActive(true);
            P1ATK.transform.SetParent(P1LH.transform);
            P1ATK.transform.SetPositionAndRotation(P1LH.transform.position, P1LH.transform.rotation);
            StartCoroutine(Attacker(P1atkTime, 0.3f, player1, DMG, !P));
        }
        else
        {
            player2.SetInteger("AnimState", 2);
        }
    }


    IEnumerator Attacker(float clip, float time, Animator anim, float DMG, bool player)
    {
        yield return new WaitForSeconds(clip - time);
        anim.SetInteger("AnimState", 1);
        P1ATK.transform.parent.DetachChildren();
        while (Vector3.Distance(P1ATK.transform.position, P2.transform.position) > 0.05f)
        { 
                P1ATK.transform.position = Vector3.Lerp(P1ATK.transform.position, P2.transform.position, Time.fixedDeltaTime * P1AtkSpeed );    
                yield return null;
        }
            LowerHP(player, DMG);
            AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[0]);
        P1ATK.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartATK();
    }


    public void UpdateAnimClipTimes()
    {
        AnimationClip[] p1clips = player1.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in p1clips)
        {
            switch (clip.name)
            {
                case "ATK":
                    P1atkTime = clip.length;
                    break;
                default:
                    return;                  
            }
        }
    }


}
