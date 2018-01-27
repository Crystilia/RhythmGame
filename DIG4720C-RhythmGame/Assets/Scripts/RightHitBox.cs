using UnityEngine;

public class RightHitBox : MonoBehaviour
{

    bool InHitBox = false;

    private GameObject Note = null;
    // Use this for initialization

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
        if (Input.GetKeyDown(KeyCode.RightArrow) && Note != null)
            Destroy(Note);

    }
}
