using UnityEngine;

public class UpHitBox : MonoBehaviour
{

    private bool InHitBox = false;
    private bool Bomb = false;
    private bool PowerUp = false;
    private Manager mngr;
    private GameObject Note = null;
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



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Note != null && InHitBox && !Bomb && !PowerUp)
        {
            Destroy(Note);
            mngr.RaisePU();
            InHitBox = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && Note != null && InHitBox && Bomb && !PowerUp)
        {
            Destroy(Note);
            mngr.LowerHP();
            Bomb = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && Note != null && InHitBox && !Bomb && PowerUp)
        {
            Destroy(Note);
            PowerUp = false;
            mngr.MaxPU();
        }
    }
}
