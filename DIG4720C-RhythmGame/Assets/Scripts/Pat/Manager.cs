﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Manager : MonoBehaviour
{
    #region vars
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
    float CurrentP1DMG = .4f;
    int P1DMG = 200;
    int P2DMG = 200;
    float CurrentP2DMG = 0.4f;
    float P1Uses = 2.5f;
    float P2Uses = 2.5f;
    public GameObject P1ATK;
    public GameObject P2ATK;
    public GameObject P1LH;
    public GameObject P2LH;
    public GameObject P1;
    public GameObject P2;
    public float P1AtkSpeed = 0.006f;
    public float P2AtkSpeed = 0.006f;
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
    public bool p1activeATK = false;
    public bool p2activeATK = false;
    public bool isAI = false;
    private int Rand;
    private bool AIHit = false;
    public bool P2CanDodge = false;
    public bool P1CanDodge = false;
    private ParticleSystem P1Body;
    private ParticleSystem P2Body;
    private GameObject P1M;
    private GameObject P2M;
    public Texture[] BGs;
    public MeshRenderer BG;
    static public float BossDmg = 0;
    private int DanceRand;
    #endregion

    // Use this for initialization
    void Start()
    {
        AM.on = false;

        #region initialization
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
        P2LH = player2.GetComponentInParent<Transform>().GetChild(3).gameObject;
        P1Lerp = player1.GetComponentInParent<Lerping>();
        P2Lerp = player2.GetComponentInParent<Lerping>();
        P1Body = P1.GetComponentInChildren<ParticleSystem>();
        P2Body = P2.GetComponentInChildren<ParticleSystem>();
        P1M = GameObject.Find("P1_AtkMiss");
        P2M = GameObject.Find("P2_AtkMiss");

        #endregion


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SinglePlayer") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MultiPlayer"))
        {
            AudioManager.soundSrc[0].clip = AudioManager.sfx[5];
            AudioManager.soundSrc[0].Play();
        }
        //button = GameObject.Find("Next Button");
        if (gameover != null)
        {
            gameover.transform.parent.gameObject.SetActive(false);
            gameoverMenu.SetActive(false);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SinglePlayer") && PauseMenu.stage == 3)
        {
            StartCoroutine(RemoveAfterMLP());
        }
    }


    //whenever a player or ai takes damage
    public void LowerHP(bool P, float Dmg)
    {
        if (P)
        {
            if (P1CurrentHP > 0)
            {
                P1CurrentHP = P1CurrentHP - Dmg;
                P1HP.fillAmount = P1CurrentHP;
                AudioManager.soundSrc[3].PlayOneShot(AudioManager.sfx[12]);
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
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MultiPlayer"))
                AudioManager.soundSrc[3].PlayOneShot(AudioManager.sfx[12]);
            }
            else
            {
                P2CurrentHP = 0;
                P2HP.fillAmount = P2CurrentHP;
                GameOver(1);
            }
        }
    }


    //whenever a player or ai hits a note gain meter here
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
        if (P == false)
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
                AIHit = true;
                P2PU.fillAmount = P2CurrentPU;
                P2PU.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }


    //power ups grant full meter
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

    //exit the application
    public void ExitGame()
    {
        Application.Quit();
    }

    //storing the number of notes left in the song
    public void SongDur()
    {
        SG.MaxNotes--;
        if (SG.MaxNotes <= 0)
        {
            GameOver(0);
        }
    }
    //all possible endings go here
    public void GameOver(int Condition)
    {
        if (canB)
        {
            StartCoroutine(SlowDown(1));
            gameover.transform.parent.gameObject.SetActive(true);
            gameoverMenu.SetActive(true);
            canB = false;
            if (PauseMenu.stage != 3)
            {
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
            else if (PauseMenu.stage == 3)
            {
                if (Condition == 2)
                {
                    gameover.GetComponent<TextMeshProUGUI>().text = "You Lost!";
                    DoorL.SetInteger("AnimState", 1);
                    player1.SetInteger("AnimState", 4);
                    P1Lerp.die(true);
                }
                else if (Condition == 1)
                {
                    gameover.GetComponent<TextMeshProUGUI>().text = "You Beat the Game!";
                    DoorR.SetInteger("AnimState", 1);
                    player2.SetInteger("AnimState", 4);
                    P2Lerp.die(false);

                }
                else if (SG.MaxNotes == 0 && P1CurrentHP > P2CurrentHP)
                {
                    gameover.GetComponent<TextMeshProUGUI>().text = "You Win!";
                    DoorR.SetInteger("AnimState", 1);
                    player2.SetInteger("AnimState", 4);
                    P2Lerp.die(false);

                }
                else if (SG.MaxNotes == 0 && P1CurrentHP < P2CurrentHP)
                {
                    gameover.GetComponent<TextMeshProUGUI>().text = "You Lost!";
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
        }
    }

    public void Dance()
    {

        DanceRand = Random.Range(6, 10);
        player1.SetInteger("AnimState", DanceRand);
        DanceRand = Random.Range(6, 10);
        player2.SetInteger("AnimState", DanceRand);
    }

    //run every frame to see if a player or ai is trying to attack or dodge
    public void StartATK()
    {
        #region P1
        if (P1CanDodge == false)
        {
            if (p2activeATK == false)
            {
                //player1 attack
                if (p1canUseSpecial && Input.GetKeyDown(KeyCode.Space) && P1Drain == false)
                {
                    P2CanDodge = true;
                    p1activeATK = true;
                    P1PU.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
                    P1Drain = true;
                    P1DMG = 200;
                    P1Uses+=0.3f;

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
                    CurrentP1DMG = Mathf.Clamp01((CurrentP1DMG / P1Uses));
                    P1Drain = false;
                    AttackAnim(true, CurrentP1DMG);
                    P1CurrentHP = Mathf.Clamp01(P1CurrentHP + ((1 - CurrentP1DMG)/ P1Uses));
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
                  //  AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[0]);
                }
            }
        }

        else if (P1CanDodge == true && Input.GetKeyDown(KeyCode.Space))
        {
            P1Dodge = true;
        }
        #endregion

        #region P2/AI
        if (P2CanDodge == false)
        {
            //player2 attack
            if (p1activeATK == false && isAI == false)
            {
                if (p2canUseSpecial && Input.GetKeyDown(KeyCode.LeftControl) && isAI == false && P2Drain == false)
                {
                    P1CanDodge = true;
                    p2activeATK = true;
                    P2PU.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
                    P2Drain = true;
                    P2DMG = 200;
                    P2Uses+=0.3f;


                }
                if (P2Drain)
                {
                    P2DMG -= 1;
                    CurrentP2DMG = Mathf.Clamp01((P2DMG / 200f));
                    P2PU.fillAmount = CurrentP2DMG;
                    P2CurrentPU = P2PU.fillAmount;
                }
                if (p2canUseSpecial && Input.GetKeyUp(KeyCode.B) && isAI == false)
                {
                    CurrentP2DMG = Mathf.Clamp01(CurrentP2DMG / P2Uses);
                    P2Drain = false;
                    AttackAnim(false, CurrentP2DMG);
                    P2CurrentHP = Mathf.Clamp01(P2CurrentHP + ((1 - CurrentP2DMG)/P2Uses));
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
                  //  AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[1]);
                }
            }

            else if (isAI)
            {
                if (p2canUseSpecial && p1activeATK == false)
                {
                    Rand = Random.Range(0, 81);
                }
          
                if (p2canUseSpecial && p1activeATK == false && P2Drain == false)
                {
                   
                    if (AIHit && Rand == 30)
                    {
                        P1CanDodge = true;
                        p2activeATK = true;
                        P2PU.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
                        P2Drain = true;
                        P2DMG =200;
                        P2Uses+=.3f;
                        AIHit = false;
                    }
                    
                }
                else if (P2Drain)
                {
                    if (P2DMG > 0)
                    {
                        P2DMG -= 1;
                        CurrentP2DMG = Mathf.Clamp01(P2DMG / 200f);
                        P2PU.fillAmount = CurrentP2DMG;
                        P2CurrentPU = P2PU.fillAmount;
                        Rand = Random.Range(0, 81);

                    }
                    else
                    {
                        //CurrentP2DMG = Mathf.Clamp01(CurrentP2DMG / P2Uses);

                        P2Drain = false;
                        P2CurrentPU = 0;
                        P2PU.fillAmount = P2CurrentPU;
                        p2canUseSpecial = false;
                        P2PU.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
                        CurrentP2DMG = 0;
                        //AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[1]);
                    }
                    //   Rand = Random.Range(0, 31);
                }
                if (p2canUseSpecial && Rand == 5 && P2DMG < 180)
                {
                    CurrentP2DMG = (Mathf.Clamp01(CurrentP2DMG / P2Uses) + BossDmg);
                    P2Drain = false;


                    AttackAnim(false, CurrentP2DMG);
                    P2CurrentHP = Mathf.Clamp01(P2CurrentHP + ((1 - CurrentP2DMG)/P2Uses));
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
                   // AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[1]);
                }

            }
        }

        else if (P2CanDodge == true)
        {
            if (isAI == false)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    P2Dodge = true;
                }
            }
            else if(isAI == true)
            {
                Rand = Random.Range(0, 200);
                if (Rand == 5)
                {
                    P2Dodge = true;
                }
            }
        }

        #endregion


    }

    //making the attack stick to a player or ai and chosing the animation
    void AttackAnim(bool P, float DMG)
    {
        if (P)
        {
            rot = player1.GetComponent<Transform>().rotation;
            pos = player1.GetComponent<Transform>().position;
            player1.SetInteger("AnimState", 1);
            P1ATK.SetActive(true);
           // player1.applyRootMotion = true;
            P1ATK.transform.SetParent(P1LH.transform);
            P1ATK.transform.SetPositionAndRotation(P1LH.transform.position, P1LH.transform.rotation);
            StartCoroutine(Attacker(P1atkTime, (P1atkTime / 2.0f), player1, DMG, false));
        }
        else if (P == false)
        {
            rot = player2.GetComponent<Transform>().rotation;
            pos = player2.GetComponent<Transform>().position;
            player2.SetInteger("AnimState", 2);
           // player2.applyRootMotion = true;
            P2ATK.SetActive(true);
            P2ATK.transform.SetParent(P2LH.transform);
            P2ATK.transform.SetPositionAndRotation(P2LH.transform.position, P2LH.transform.rotation);
            StartCoroutine(Attacker(P2atkTime, (P2atkTime/2.0f), player2, DMG, true));
        }
    }

    #region IEnums
    //time the dmg and dodge
    IEnumerator Attacker(float clip, float time, Animator anim, float DMG, bool player)
    {
        yield return new WaitForSeconds(clip - time);
        anim.SetInteger("AnimState", 6);
      //  anim.applyRootMotion = false;
        
        if (player == false)
        {
           // StartCoroutine(resetRot(player1.GetComponent<Transform>(), rot));
           // StartCoroutine(resetPos(player1.GetComponent<Transform>(), pos));
            P1ATK.transform.parent.DetachChildren();
            AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[11]);
            while (Vector3.Distance(P1ATK.transform.position, P2.transform.position) > 1f)
            {
                P1ATK.transform.position = Vector3.Lerp(P1ATK.transform.position, P2.transform.position, Time.time * P1AtkSpeed);
                if (P2Dodge == false)
                {
                    player2.SetInteger("AnimState", 13);
                    //break;
                }
                else if (P2Dodge == true)
                {
                    player2.SetInteger("AnimState", 3);

                }
                if (Vector3.Distance(P1ATK.transform.position, P1.transform.position) < 5f)
                {
                    P2CanDodge = false;
                }
                yield return null;
            }

            if (P2Dodge == false)
            {
                P2Body.Play();
                LowerHP(player, DMG);
                AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[10]);
                P1ATK.SetActive(false);
                p1activeATK = false;
            }
            else if (P2Dodge == true)
            {

                AudioManager.soundSrc[1].PlayOneShot(AudioManager.sfx[13]);
                //attack miss stuff here
                player2.SetInteger("AnimState", 8);
                P2Dodge = false;
                //   P1ATK.SetActive(false);
                StartCoroutine(ATKLerp(P1ATK, P2M, P1AtkSpeed));
                p1activeATK = false;
            }
          
        }
        else if (player == true)
        {
            //StartCoroutine(resetRot(player2.GetComponent<Transform>(), rot));
           // StartCoroutine(resetPos(player2.GetComponent<Transform>(), pos));
            P2ATK.transform.parent.DetachChildren();
            AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[11]);
            while (Vector3.Distance(P2ATK.transform.position, P1.transform.position) > 1f)
            {
                P2ATK.transform.position = Vector3.Lerp(P2ATK.transform.position, P1.transform.position, Time.time * P2AtkSpeed);

                if (P1Dodge == false)
                {
                    player1.SetInteger("AnimState", 13);
                }
                if (P1Dodge == true)
                {
                    player1.SetInteger("AnimState", 3);
                }
                if (Vector3.Distance(P2ATK.transform.position, P2.transform.position) < 5f)
                {
                    P1CanDodge = false;
                }
                yield return null;
            }
           // AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[0]);
            if (P1Dodge == false)
            {
                P1Body.Play();
                LowerHP(player, DMG);
                AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[10]);
                P2ATK.SetActive(false);
                p2activeATK = false;
            }
            else if (P1Dodge == true)
            {
                

                AudioManager.soundSrc[2].PlayOneShot(AudioManager.sfx[13]);
                //attack miss stuff here
                player1.SetInteger("AnimState", 8);
              //  P2ATK.SetActive(false);
                p2activeATK = false;
                P1Dodge = false;
                StartCoroutine(ATKLerp(P2ATK, P1M, P2AtkSpeed));
            }

        }
        
    }
    //if dodge lerp past player
    IEnumerator ATKLerp(GameObject ATK, GameObject POS, float SPEED)
    {
        while (Vector3.Distance(ATK.transform.position, POS.transform.position) > 1f)
        {
            ATK.transform.position = Vector3.Lerp(ATK.transform.position, POS.transform.position, Time.time * (SPEED/2.0f));
            yield return null;
        }
        ATK.SetActive(false);
        P1CanDodge = false;
        P2CanDodge = false;
        yield return null;
    }
    //for root motion / not in use
    IEnumerator resetPos(Transform player, Vector3 OrgPos)
    {
        while (Vector3.Distance(player.position, OrgPos) > 0.05f)
        {
            player.position = Vector3.Lerp(player.position, OrgPos, Time.smoothDeltaTime * 500);
            yield return null;
        }
    }
    //for root motion / not in use
    IEnumerator resetRot(Transform player, Quaternion OrgRot)
    {
        while (player.transform.rotation.y != OrgRot.y)
        {
            player.rotation = Quaternion.RotateTowards(player.rotation, OrgRot, Time.smoothDeltaTime * 500);
            yield return null;
        }
    }

    IEnumerator RemoveAfterMLP()
    {
        if (gameover != null)
        {
            gameover.GetComponent<TextMeshProUGUI>().text = "BOSS BATTLE!";
            gameover.transform.parent.gameObject.SetActive(true);

        }
        yield return new WaitForSeconds(1);
        if (gameover != null)
        {
            gameover.transform.parent.gameObject.SetActive(false);
            gameoverMenu.SetActive(false);
        }

        yield return new WaitForSeconds(1);
    }

    IEnumerator SlowDown(float x)
    {
        yield return new WaitForSeconds(0);
        while (x > 0)
        {
            x -= .01f;
            if (Time.timeScale > 0.2f)
            {
                
                Time.timeScale = x;
            }
            else
            {
                Time.timeScale = 0;
            }
            yield return null;
        }
    }
        #endregion
    

        // Update is called once per frame
        void Update()
    {
        StartATK();
    }

    private void FixedUpdate()
    {
      //  Dance();
    }
    // get how long the attack animation is for calculating when the attack detatches
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
