using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedNoteKill : MonoBehaviour {
    private Manager mngr;
    public bool Player;
    // Use this for initialization
    void Start () {
        mngr = GameObject.Find("Manager").GetComponent<Manager>();
	}
    private void OnTriggerEnter(Collider note)
    {
        if(note.tag == "Note")
        {
            mngr.LowerHP(Player, .02f);
            Destroy(note.gameObject);
        }
        if (note.tag == "Bomb")
        {
            Destroy(note.gameObject);
        }
    }
}
