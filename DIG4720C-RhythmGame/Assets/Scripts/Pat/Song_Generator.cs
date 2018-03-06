using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Song_Generator : MonoBehaviour {


    private bool MakePowerUp = true;
    private bool MakeBadNote = true;
    private Vector2 NotePos;
    private Vector2 ArrNotePos;
    private Color pixelC;
    private int ChangeNote;
    private GameObject CurrentNote;

    public Texture2D song;
    public ColorToPrefab[] Note_Colors;
    public GameObject BadNote;
    public GameObject GoodNote;
    private Transform spawner;
    public int MaxNotes = 1;
    bool count = true;
    // Use this for initialization
    void Start () {
        spawner = GameObject.Find("NoteSpawn").GetComponent<Transform>();
        GenerateSong();
    }

    void GenerateSong()
    {
        for(int x = 0; x < song.width; x++)
        {
            for (int y = 0; y < song.height; y++)
            {
                GenerateNote(x, y);
            }
        }
    }

    void GenerateNote(int x, int y)
    {
        pixelC = song.GetPixel(x, y);
   
        //ignore transparent pixels
        if (pixelC.a == 0)
        {
            return;
        }


        foreach (ColorToPrefab Note in Note_Colors)
        {
            //player 1
            if (Note.color.Equals(pixelC))
            {
                // multiply x to create space between notes, add to x to shift all notes left or right.
             
                Vector2 ArrNotePos = new Vector2(x*2,y);
                Instantiate(Note.BasicNote, ArrNotePos, Quaternion.identity, spawner);
                MaxNotes++;
            }
            //player 2
            if (Note.color.Equals(pixelC))
            {
                // multiply x to create space between notes, add to x to shift all notes left or right.

                Vector2 ArrNotePos = new Vector2((x* 2)+12, y);
                Instantiate(Note.BasicNote, ArrNotePos, Quaternion.identity, spawner);
            }
        }
        if(count)
        {
            MaxNotes--;
            count = !count;
        }
    }


    public void Rand(GameObject other)
    {
        if (MakeBadNote == true)
        {
            ChangeNote = Random.Range(0, 5);
            if (ChangeNote == 1)
            {
                NotePos = other.transform.position;
                CurrentNote = Instantiate(BadNote, NotePos, Quaternion.identity);
                CurrentNote.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity;
                Destroy(other);
            }
        }
        if (MakePowerUp == true)
        {
            ChangeNote = Random.Range(0, 100);
            if (ChangeNote == 2)
            {
                NotePos = other.transform.position;
                CurrentNote = Instantiate(GoodNote, NotePos, Quaternion.identity);
                CurrentNote.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity;
                Destroy(other);
            }
        }
    }
}
