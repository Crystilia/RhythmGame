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

    //[Range(1.7f, 3)]
    //public float Disolver;
    // Use this for initialization

    private void Start()
    {
        mngr = GameObject.Find("Manager").GetComponent<Manager>();
        hitImg = this.transform.GetComponentInChildren<ParticleSystem>();
    }
        private void OnTriggerEnter(Collider note)
    {
        if (IsAI)
        {
            if (note.gameObject.tag == "Note")
            {
                InHitBox = true;
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
            else if (note.gameObject.tag == "PowerUp")
            {
                InHitBox = true;
                PowerUp = true;
                Note = note.gameObject;
                pressbutton(box);
            }
        }
        if (note.gameObject.tag == "Note")
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

    private void OnTriggerExit(Collider note)
    {
        if (note.gameObject.tag == "Note")
        {
            InHitBox = false;
        }
        if (note.gameObject.tag == "Bomb")
        {
            InHitBox = false;
            Bomb = false;
        }
        if (note.gameObject.tag == "PowerUp")
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
                    StartCoroutine(MyCorutine(2.3f, Note));
                    mngr.RaisePU(P);
                    InHitBox = false;
                }
                else if (Note != null && InHitBox && Bomb && !PowerUp)
                {
                   // DisolveNote = Note.GetComponent<Material>();
                    StartCoroutine(MyCorutine(2.3f, Note));
                    hitImg.Play();
                    mngr.LowerHP(P,0.05f);
                    Bomb = false;
                }
                else if (Note != null && InHitBox && !Bomb && PowerUp)
                {
                   // DisolveNote = Note.GetComponent<Material>();
                    StartCoroutine(MyCorutine(2.3f, Note));
                    hitImg.Play();
                    PowerUp = false;
                    mngr.MaxPU(P);
                }
    }

    void pressbutton(int i)
    {
        if (IsAI)
        {
            hit(false);
        }
        if (i == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            hit(true);
        }
        if (i == 1 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            hit(true);
        }
        if (i == 2 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            hit(true);
        }
        if (i == 3 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            hit(true);
        }
        if (i == 4 && Input.GetKeyDown(KeyCode.A))
        {
            hit(false);
        }
        if (i == 5 && Input.GetKeyDown(KeyCode.D))
        {
            hit(false);
        }
        if (i == 6 && Input.GetKeyDown(KeyCode.W))
        {
            hit(false);
        }
        if (i == 7 && Input.GetKeyDown(KeyCode.S))
        {
            hit(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        pressbutton(box);
    }

    IEnumerator MyCorutine (float range, GameObject Note)
    {
        while(range > 1.8f)
        {
            range -= 1f * Time.smoothDeltaTime;
            if (Note != null)
            {
                if (Note.tag == "PowerUp")
                {
                    Note.GetComponent<MeshRenderer>().material.SetFloat("_DisolveStart", range);
                    float size = Note.GetComponent<MeshRenderer>().material.GetFloat("_ExtrudeAmt");
                    Note.GetComponent<MeshRenderer>().material.SetFloat("_ExtrudeAmt", size - .02f);
                }
                else if (Note.tag == "Bomb")
                {
                    Note.GetComponent<MeshRenderer>().material.SetFloat("_DisolveStart", range);
                    float size = Note.GetComponent<MeshRenderer>().material.GetFloat("_ExtrudeAmt");
                    Note.GetComponent<MeshRenderer>().material.SetFloat("_ExtrudeAmt", size + 1f);
                    Note.GetComponent<MeshRenderer>().material.SetFloat("_TimeSize", 0f);
                }
                else
                {
                    Note.GetComponent<MeshRenderer>().material.SetFloat("_DisolveStart", range);
                    float size = Note.GetComponent<MeshRenderer>().material.GetFloat("_ExtrudeAmt");
                    Note.GetComponent<MeshRenderer>().material.SetFloat("_ExtrudeAmt", size + .06f);
                }
            }
            yield return null;

        }
        Destroy(Note);
    }
}
