using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer am;

    public void SetVolume( float Vol)
    {
        am.SetFloat("Volume", Vol);
    }

    public void SetWindow(bool Option)
    {
                Screen.fullScreen = Option;   
    }
}