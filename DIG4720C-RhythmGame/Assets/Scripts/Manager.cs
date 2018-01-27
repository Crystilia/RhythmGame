using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    private Image P1HP;
    float P1CurrentHP = 1;
	// Use this for initialization
	void Start () {
        P1HP = GameObject.Find("P1HP").GetComponent<Image>();
	}
	
    public void LowerHP()
    {
        P1CurrentHP = P1CurrentHP - 0.1f;
    }
	// Update is called once per frame
	void Update () {
        P1HP.fillAmount = P1CurrentHP;


    }


}
