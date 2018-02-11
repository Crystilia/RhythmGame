using UnityEngine;

public class HitBox : MonoBehaviour
{

    private bool InHitBox = false;
    private bool Bomb = false;
    private bool PowerUp = false;
    private Manager mngr;
    private GameObject Note = null;
    public int box;
    // Use this for initialization

    private void Start()
    {
        mngr = GameObject.Find("Manager").GetComponent<Manager>();
    }
    private void OnTriggerEnter(Collider note)
    {
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
                    Destroy(Note);
                    mngr.RaisePU(P);
                    InHitBox = false;
                }
                else if (Note != null && InHitBox && Bomb && !PowerUp)
                {
                    Destroy(Note);
                    mngr.LowerHP(P);
                    Bomb = false;
                }
                else if (Note != null && InHitBox && !Bomb && PowerUp)
                {
                    Destroy(Note);
                    PowerUp = false;
                    mngr.MaxPU(P);
                }
    }

    void pressbutton(int i)
    {
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
        if (i == 4 && Input.GetKeyDown(KeyCode.W))
        {
            hit(false);
        }
        if (i == 5 && Input.GetKeyDown(KeyCode.A))
        {
            hit(false);
        }
        if (i == 6 && Input.GetKeyDown(KeyCode.S))
        {
            hit(false);
        }
        if (i == 7 && Input.GetKeyDown(KeyCode.D))
        {
            hit(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        pressbutton(box);
    }
}
