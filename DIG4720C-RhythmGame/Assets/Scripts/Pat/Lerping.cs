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
        void Start()
        {
            mngr = GameObject.Find("Manager").GetComponent<Manager>();
        mngr.player1.SetInteger("AnimState", 4);
        mngr.player2.SetInteger("AnimState", 4);
        startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
            StartCoroutine(lerper(startMarker, endMarker));
    }





    IEnumerator lerper(Transform start, Transform end)
    {
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
        mngr.player1.SetInteger("AnimState", 6);
        mngr.player2.SetInteger("AnimState", 6);
    }
}