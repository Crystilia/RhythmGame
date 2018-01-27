using UnityEngine;

public class LeftHitBox : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Note != null)
            Destroy(Note);

    }
}
