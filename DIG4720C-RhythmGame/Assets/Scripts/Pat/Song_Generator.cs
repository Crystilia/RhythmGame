﻿using System.Collections;
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
    Manager manager;
    public Texture2D song;
    public ColorToPrefab[] Note_Colors;
    public GameObject BadNote;
    public GameObject GoodNote;
    private Transform spawner;
    public int MaxNotes = 1;
    bool count = true;
    float spawnx;
    float spawny;
    float spready;
    private GameObject current_note;
    private float curPos;
    // Use this for initialization
    void Start () {
        spawner = GameObject.Find("NoteSpawn").GetComponent<Transform>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        spawnx = manager.NoteSpawnX;
        spawny = manager.NoteSpawnY;
        spready = manager.NoteSpreadY;
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
             
                Vector2 ArrNotePos = new Vector2(x* spawnx, (y* spready) + spawny);
                current_note = Instantiate(Note.BasicNote, ArrNotePos, Quaternion.identity, spawner);
                curPos = current_note.transform.position.x;
                if (curPos == 0 )
                {
                    current_note.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1);
                }
                else if (curPos == 2 )
                {
                    current_note.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 0);
                }
                else if (curPos == 4 )
                {
                    current_note.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1);
                }
                else if (curPos == 6 )
                {
                    current_note.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
                }
                MaxNotes++;
            }
            //player 2
            if (Note.color.Equals(pixelC))
            {
                // multiply x to create space between notes, add to x to shift all notes left or right.

                Vector2 ArrNotePos = new Vector2((x* spawnx) +12, (y * spready) + spawny);
                current_note = Instantiate(Note.BasicNote, ArrNotePos, Quaternion.identity, spawner);
                curPos = current_note.transform.position.x;
                if (curPos == 12)
                {
                    current_note.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1);
                }
                else if (curPos == 14)
                {
                    current_note.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 0);
                }
                else if (curPos == 16)
                {
                    current_note.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1);
                }
                else if (curPos == 18)
                {
                    current_note.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
                }
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
                CurrentNote.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity;
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
                CurrentNote.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity;
                Destroy(other);
            }
        }
    }
}
