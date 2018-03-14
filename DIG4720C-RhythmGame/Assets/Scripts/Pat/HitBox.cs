using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class HitBox : MonoBehaviour
{

    private bool InHitBox = false;
    private bool Bomb = false;
    private bool PowerUp = false;
    private Manager mngr;
    private GameObject Note = null;
    public int box;
    public ParticleSystem hitImg;
    public Material DisolveNote;
    public Material DisolveBomb;
    public bool IsAI = false;
    public int AIlvl;
    public bool SongDurCounter = false;
    private int Rand;
    private int AIHitPercent;
    //[Range(1.7f, 3)]
    //public float Disolver;
    // Use this for initialization

    private void Start()
    {
        AIHitPercent = PlayerPrefs.GetInt("AI");
        mngr = GameObject.Find("Manager").GetComponent<Manager>();
        hitImg = this.transform.GetComponentInChildren<ParticleSystem>();
    }
        private void OnTriggerEnter2D(Collider2D note)
    {
        Note = null;
       note.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
        if (IsAI)
        {
            Rand = Random.Range(0, 101);
            if (note.gameObject.tag == "Note")
                {
                    InHitBox = true;
                    Note = note.gameObject;
                    pressbutton(box);
                }
                else if (note.gameObject.tag == "PowerUp")
                {
                    InHitBox = true;
                    PowerUp = true;
                    Note = note.gameObject;
                    pressbutton(box);
                }
                else if (note.gameObject.tag == "Bomb")
                {
                    InHitBox = true;
                    Bomb = true;
                    Note = note.gameObject;
                    pressbutton(box);
                }
        }

        else if (note.gameObject.tag == "Note")
        {
            InHitBox = true;
            Note = note.gameObject;
        }
        else if (note.gameObject.tag == "Bomb")
        {
            InHitBox = true;
            Bomb = true;
            Note = note.gameObject;
        }
        else if (note.gameObject.tag == "PowerUp")
        {
            InHitBox = true;
            PowerUp = true;
            Note = note.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D note)
    {
        if (Note == note)
        { Note = null; }
        note.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);

        if (note.gameObject.tag == "Note")
        {
            InHitBox = false;
        }
        else if (note.gameObject.tag == "Bomb")
        {
            InHitBox = false;
            Bomb = false;
        }
        else if (note.gameObject.tag == "PowerUp")
        {
            InHitBox = false;
            PowerUp = false;
        }
    }

    void hit(bool P)
    {
        if (Note != null && InHitBox && !Bomb && !PowerUp)
                {
                    hitImg.Play();
            //  DisolveNote = Note.GetComponent<Material>();
              StartCoroutine(MyCorutine(6.87f, Note));
            Note.GetComponent<BoxCollider2D>().enabled = false;
           // Note.SetActive(false);
            mngr.RaisePU(P);
            InHitBox = false;
                    if (SongDurCounter)
                     {
                        mngr.SongDur();
                     }
                }
         else if (Note != null && InHitBox && Bomb && !PowerUp)
                {
            // DisolveNote = Note.GetComponent<Material>();
                StartCoroutine(MyCorutine(6.87f, Note));
            Note.GetComponent<BoxCollider2D>().enabled = false;
           // Note.SetActive(false);
            hitImg.Play();
                    mngr.LowerHP(P,0.05f);
                    Bomb = false;
            InHitBox = false;
            if (SongDurCounter)
                    {
                      mngr.SongDur();
                    }
        }
         else if (Note != null && InHitBox && !Bomb && PowerUp)
                {
            // DisolveNote = Note.GetComponent<Material>();
               StartCoroutine(MyCorutine(6.87f, Note));
            Note.GetComponent<BoxCollider2D>().enabled = false;
            //Note.SetActive(false);
                    hitImg.Play();
                    PowerUp = false;
            InHitBox = false;
            mngr.MaxPU(P);
                    if (SongDurCounter)
                    {
                      mngr.SongDur();
                    }
        }
    }

    void pressbutton(int i)
    {
        if (IsAI)
        {
            if (Rand <= AIHitPercent)
            {
                hit(false);
            }
        }
        else if (i == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            hit(true);
        }
        else if (i == 1 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            hit(true);
        }
        else if (i == 2 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            hit(true);
        }
        else if (i == 3 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            hit(true);
        }
        else if (i == 4 && Input.GetKeyDown(KeyCode.A))
        {
            hit(false);
        }
        else if (i == 5 && Input.GetKeyDown(KeyCode.D))
        {
            hit(false);
        }
        else if (i == 6 && Input.GetKeyDown(KeyCode.W))
        {
            hit(false);
        }
        else if (i == 7 && Input.GetKeyDown(KeyCode.S))
        {
            hit(false);
        }
    }

    void Update()
    {
        pressbutton(box);
    }

    IEnumerator MyCorutine (float range, GameObject Note)
    {
        /* 
        float size;
        Material NoteMat = Note.GetComponent<MeshRenderer>().material;
        int tag;
        if (Note.tag == "PowerUp")
        {
            tag = 0;
        }
        else if (Note.tag == "Bomb")
        {
            tag = 1;
        }
        else
        {
            tag = 2;
        }

       while (range > 6.2f)
        {
            range -= 2f * Time.smoothDeltaTime;
           // Debug.Log(range);
                if (tag == 0)
                {
                    NoteMat.SetFloat("_DisolveStart", range);
                    size = NoteMat.GetFloat("_ExtrudeAmt");
                    NoteMat.SetFloat("_ExtrudeAmt", size - .006f);
                }
                else if (tag == 1)
                {
                    NoteMat.SetFloat("_DisolveStart", range);
                    size = NoteMat.GetFloat("_ExtrudeAmt");
                    NoteMat.SetFloat("_ExtrudeAmt", size + .07f);
                    NoteMat.SetFloat("_TimeSize", 0f);
                }
                else
                {
                    NoteMat.SetFloat("_DisolveStart", range);
                    size = NoteMat.GetFloat("_ExtrudeAmt");
                    NoteMat.SetFloat("_ExtrudeAmt", size + .009f);
                }
            yield return null;

        }
        */
        float  DeletethisF = range;
        Note.SetActive(false);
        yield return null;
    }
}
