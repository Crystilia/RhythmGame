using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    private Image P1HP;
    private Image P1PU;
    float P1CurrentHP = 1;
    float P1CurrentPU = 0;
    bool canUseSpecial = false;
    // Use this for initialization
    void Start () {
        P1HP = GameObject.Find("P1HP").GetComponent<Image>();
        P1PU = GameObject.Find("P1PU").GetComponent<Image>();
    }
	
    public void LowerHP()
    {
        P1CurrentHP = P1CurrentHP - 0.1f;
    }

    public void RaisePU()
    {
        if (P1PU.fillAmount < 1f)
        {
            P1CurrentPU = P1CurrentPU + 0.1f;
        }
        else if (P1PU.fillAmount >= 1f)
        {
            P1CurrentPU = 1f;
            canUseSpecial = true;
        }
    }

    public void MaxPU()
    {
        P1CurrentPU = 1f;
    }

    // Update is called once per frame
    void Update () {
        P1HP.fillAmount = P1CurrentHP;
        P1PU.fillAmount = P1CurrentPU;

        if (Input.GetKeyDown(KeyCode.Space) && canUseSpecial)
        {

            P1CurrentPU = 0;
            P1PU.fillAmount = P1CurrentPU;
            canUseSpecial = false;
        }


    }
}
