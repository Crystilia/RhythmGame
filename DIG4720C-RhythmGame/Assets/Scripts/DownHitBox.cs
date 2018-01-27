using UnityEngine;

public class DownHitBox : MonoBehaviour
{

    bool InHitBox = false;
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
    }

    private void OnTriggerExit(Collider note)
    {
        if (note.gameObject.tag == "Note")
        {
            InHitBox = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && Note != null && InHitBox)
        {
            Destroy(Note);
            mngr.LowerHP();
        }
    }
}
