using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerping : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private Manager mngr;
    public Transform p1Pos;
    public Transform p2Pos;
    public Transform p1Death;
    public Transform p2Death;
    public ParticleSystem[] Stars;
    public bool star = true;
    void Start()
    {
        p1Death = GameObject.Find("P1_DeathLerp").transform;
        p2Death = GameObject.Find("P2_DeathLerp").transform;
        mngr = GameObject.Find("Manager").GetComponent<Manager>();
        mngr.player1.SetInteger("AnimState", 4);
        mngr.player2.SetInteger("AnimState", 4);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        StartCoroutine(lerper(startMarker, endMarker));
        star = true;
    }

    public void die(bool player)
        {
        mngr.CancelInvoke();
        if (player)
        {
            journeyLength = Vector3.Distance(p1Pos.position, p1Death.position);
            StartCoroutine(lerper(p1Pos, p1Death));
        }
        else
        {
            journeyLength = Vector3.Distance(p2Pos.position, p2Death.position);
            StartCoroutine(lerper(p2Pos, p2Death));
        }
        }

    void StopPart()
    {
        Stars[0].Stop();
        Stars[1].Stop();
    }

    public IEnumerator lerper(Transform start, Transform end)
    {
        startTime = Time.time;
        yield return null;
        while (transform.position != end.transform.position)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(start.position, end.position, fracJourney);
            if (Vector3.Distance(transform.position, end.transform.position) < 2f)
            {
                mngr.player1.SetInteger("AnimState", 5);
                mngr.player2.SetInteger("AnimState", 5);
            }
            yield return null;
        }

        if(star)
        {
            Stars[0].Play();
            Stars[1].Play();
            star = false;
            InvokeRepeating("StopPart",2.5f, 0);
            mngr.AudioManager.PlaySfx(1,15,1);
        }
        mngr.player1.SetInteger("AnimState", 6);
        mngr.player2.SetInteger("AnimState", 6);
        mngr.InvokeRepeating("Dance", 2.0f, 0.3f);
    }
}