using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class Manager : MonoBehaviour
{
    public float NoteSpeed;
    public float NoteSpawnX;
    public float NoteSpawnY;
    public float NoteSpreadY;
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
    public Animator player1;
    public Animator player2;
    public float P1atkTime;
    public float P2atkTime;
    bool P1Drain;
    bool P2Drain;
    float CurrentP1DMG = 200;
    int P1DMG = 200;
    int P2DMG = 200;
    float CurrentP2DMG = 200;
    int P1Uses = 1;
    int P2Uses = 1;
    public GameObject P1ATK;
    public GameObject P2ATK;
    public GameObject P1LH;
    public GameObject P2LH;
    public GameObject P1;
    public GameObject P2;
    float P1AtkSpeed = 2f;
    float P2AtkSpeed = 2f;
    public AM AudioManager;
    public GameObject button;
    Quaternion rot;
    Vector3 pos;
    private bool P2Dodge;
    private bool P1Dodge;
    public Animator DoorL;
    public Animator DoorR;
    public Lerping P1Lerp;
    public Lerping P2Lerp;

    // Use this for initialization
    void Start()
    {
        SG = GameObject.Find("SongManager").GetComponent<Song_Generator>();
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
        player1.SetInteger("AnimState", 6);
        player2.SetInteger("AnimState", 6);
        DoorL = GameObject.Find("DoorL").GetComponent<Animator>();
        DoorR = GameObject.Find("DoorR").GetComponent<Animator>();
        DoorL.SetInteger("AnimState", 0);
        DoorR.SetInteger("AnimState", 0);
        // edit these
        P1LH = player1.GetComponentInParent<Transform>().GetChild(3).gameObject;
        P2LH = player2.GetComponentInParent<Transform>().GetChild(4).gameObject;
        P1Lerp = player1.GetComponentInParent<Lerping>();
        P2Lerp = player2.GetComponentInParent<Lerping>();
        //button = GameObject.Find("Next Button");
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
                GameOver(2);

            }
        }
        if (P == false)
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
                GameOver(1);
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
        if (SG.MaxNotes <= 0)
        {
            GameOver(0);
        }
    }

    public void GameOver(int Condition)
    {
            gameover.SetActive(true);
            gameoverMenu.SetActive(true);
            canB = false;
        if (Condition == 2)
        {
            gameover.GetComponent<TextMeshProUGUI>().text = "P2 Wins!";
            DoorL.SetInteger("AnimState", 1);
            player1.SetInteger("AnimState", 4);
            P1Lerp.die(true);
        }
        else if (Condition == 1)
        {
            gameover.GetComponent<TextMeshProUGUI>().text = "P1 Wins!";
            DoorR.SetInteger("AnimState", 1);
            player2.SetInteger("AnimState", 4);
            P2Lerp.die(false);

        }
        else if (SG.MaxNotes == 0 && P1CurrentHP > P2CurrentHP)
        {
            gameover.GetComponent<TextMeshProUGUI>().text = "P1 Wins!";
            DoorR.SetInteger("AnimState", 1);
            player2.SetInteger("AnimState", 4);
            P2Lerp.die(false);

        }
        else if (SG.MaxNotes == 0 && P1CurrentHP < P2CurrentHP)
        {
            gameover.GetComponent<TextMeshProUGUI>().text = "P2 Wins!";
            DoorL.SetInteger("AnimState", 1);
            player1.SetInteger("AnimState", 4);
            P1Lerp.die(true);

            if (button != null)
            {
                button.SetActive(false);
            }
        }
        else if (SG.MaxNotes == 0)
        {
            gameover.GetComponent<TextMeshProUGUI>().text = "Tie!";
            DoorL.SetInteger("AnimState", 1);
            player1.SetInteger("AnimState", 4);
            P1Lerp.die(true);
            DoorR.SetInteger("AnimState", 1);
            player2.SetInteger("AnimState", 4);
            P2Lerp.die(false);

            if (button != null)
            {
                button.SetActive(false);
            }
        }
    }

    public void StartATK()
    {
        //player1 attack
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
            if (P1CurrentHP > 1)
            {
                P1CurrentHP = 1;
            }
            P1HP.fillAmount = P1CurrentHP;
            P1CurrentPU = 0;
            P1PU.fillAmount = P1CurrentPU;
            p1canUseSpecial = false;
            P1PU.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            CurrentP1DMG = 0;
            AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[0]);
        }
        //player2 attack
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
            P2CurrentHP = P2CurrentHP + CurrentP2DMG;
            if (P2CurrentHP > 1)
            {
                P2CurrentHP = 1;
            }
            P2HP.fillAmount = P2CurrentHP;
            P2CurrentPU = 0;
            P2PU.fillAmount = P2CurrentPU;
            p2canUseSpecial = false;
            P2PU.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
            CurrentP2DMG = 0;
            AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[1]);
        }
    }

    void AttackAnim(bool P, float DMG)
    {
        if (P)
        {
            rot = player1.GetComponent<Transform>().rotation;
            pos = player1.GetComponent<Transform>().position;
            player1.SetInteger("AnimState", 1);
            P1ATK.SetActive(true);
            player1.applyRootMotion = true;
            P1ATK.transform.SetParent(P1LH.transform);
            P1ATK.transform.SetPositionAndRotation(P1LH.transform.position, P1LH.transform.rotation);
            StartCoroutine(Attacker(P1atkTime, 0.3f, player1, DMG, !P));
        }
        else
        {
            rot = player2.GetComponent<Transform>().rotation;
            pos = player2.GetComponent<Transform>().position;
            player2.SetInteger("AnimState", 2);
            player2.applyRootMotion = true;
            P2ATK.SetActive(true);
            P2ATK.transform.SetParent(P2LH.transform);
            P2ATK.transform.SetPositionAndRotation(P2LH.transform.position, P2LH.transform.rotation);
            StartCoroutine(Attacker(P2atkTime, 0.3f, player2, DMG, !P));
        }
    }


    IEnumerator Attacker(float clip, float time, Animator anim, float DMG, bool player)
    {
        yield return new WaitForSeconds(clip - time);
        anim.SetInteger("AnimState", 6);
        anim.applyRootMotion = false;
        
        if (player == false)
        {
            StartCoroutine(resetRot(player1.GetComponent<Transform>(), rot));
            StartCoroutine(resetPos(player1.GetComponent<Transform>(), pos));
            P1ATK.transform.parent.DetachChildren();
            while (Vector3.Distance(P1ATK.transform.position, P2.transform.position) > 0.05f)
            {
                P1ATK.transform.position = Vector3.Lerp(P1ATK.transform.position, P2.transform.position, Time.smoothDeltaTime * P1AtkSpeed);

                if (Vector3.Distance(P1ATK.transform.position, P2.transform.position) < 1f)
                {
                    if (P2Dodge == false)
                    {
                        player2.SetInteger("AnimState", 8);
                    }
                    else
                    {
                        player2.SetInteger("AnimState", 3);
                    }
                }
                yield return null;
            }

            if (P2Dodge == false)
            {
                LowerHP(player, DMG);
                AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[0]);
                P1ATK.SetActive(false);
            }
            else
            {
                AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[2]);
            }
        }
        else if (player == true)
        {
            StartCoroutine(resetRot(player2.GetComponent<Transform>(), rot));
            StartCoroutine(resetPos(player2.GetComponent<Transform>(), pos));
            P2ATK.transform.parent.DetachChildren();
            while (Vector3.Distance(P2ATK.transform.position, P1.transform.position) > 0.05f)
            {
                P2ATK.transform.position = Vector3.Lerp(P2ATK.transform.position, P1.transform.position, Time.smoothDeltaTime * P2AtkSpeed);
                if (Vector3.Distance(P1ATK.transform.position, P2.transform.position) < 1f)
                {
                    if (P1Dodge == false)
                    {
                        player1.SetInteger("AnimState", 8);
                    }
                    else
                    {
                        player1.SetInteger("AnimState", 3);
                    }
                }
                yield return null;
            }
            LowerHP(player, DMG);
            AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[0]);
            P2ATK.SetActive(false);
            if (P1Dodge == false)
            {
                LowerHP(player, DMG);
                AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[0]);
                P2ATK.SetActive(false);
            }
            else
            {
                AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[2]);
            }
        }
    }

    IEnumerator resetPos(Transform player, Vector3 OrgPos)
    {
        while (Vector3.Distance(player.position, OrgPos) > 0.05f)
        {
            player.position = Vector3.Lerp(player.position, OrgPos, Time.smoothDeltaTime * 500);
            yield return null;
        }
    }
    IEnumerator resetRot(Transform player, Quaternion OrgRot)
    {
        while (player.transform.rotation.y != OrgRot.y)
        {
            player.rotation = Quaternion.RotateTowards(player.rotation, OrgRot, Time.smoothDeltaTime * 500);
            yield return null;
        }
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
                    case "ATKL":
                        P1atkTime = clip.length;
                        break;
                    case "ATKR":
                        P1atkTime = clip.length;
                        break;
                default:
                        break;
                }
            }
        AnimationClip[] p2clips = player2.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in p2clips)
        {
            switch (clip.name)
            {
                case "ATK":
                    P2atkTime = clip.length;
                    break;
                case "ATKL":
                    P2atkTime = clip.length;
                    break;
                case "ATKR":
                    P2atkTime = clip.length;
                    break;
                default:
                    break;
            }
        }
    }
}
