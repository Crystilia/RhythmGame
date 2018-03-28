using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonNoise : MonoBehaviour { 

    private AM AudioManager;

     private void Start()
{
    AudioManager = GameObject.Find("AM").GetComponent<AM>();
}

    public void UISfx(int i)
    {
        if (AM.on)
            AudioManager.PlaySfx(3, i, 0.5f);
        else
        {
            AM.on = true;
        }
    }

}