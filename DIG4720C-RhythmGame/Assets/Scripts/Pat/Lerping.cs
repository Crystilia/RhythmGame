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

        void Start()
        {
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
            yield return null;
        }
     
    }
}