using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedNoteKill : MonoBehaviour {
    private Manager mngr;
    public bool Player;
    public bool SongDurCounter = false;
    // Use this for initialization
    void Start () {
        mngr = GameObject.Find("Manager").GetComponent<Manager>();
	}
    private void OnTriggerEnter2D(Collider2D note)
    {
        if(note.tag == "Note")
        {
            mngr.LowerHP(Player, .02f);
            if (SongDurCounter)
            {
                mngr.SongDur();
            }
            note.gameObject.SetActive(false);
            // Destroy(note.gameObject);
        }
        else if (note.tag == "Bomb")
        {
            //  Destroy(note.gameObject);
            note.gameObject.SetActive(false);
            if (SongDurCounter)
            {
                mngr.SongDur();
            }
        }
        else if (note.tag == "PowerUp")
        {
            //  Destroy(note.gameObject);
            note.gameObject.SetActive(false);
            if (SongDurCounter)
            {
                mngr.SongDur();
            }
        }
    }
}
