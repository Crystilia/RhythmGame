using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AM : MonoBehaviour {

    public AudioClip[] sfx;
    public AudioSource[] soundSrc;
    public static bool on = false;
    public static AM am;
    // Use this for initialization
    void Awake() {
  

        if (am == null)
        {
            am = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        soundSrc = GetComponents<AudioSource>();
        //soundSrc[0].pitch = 0.5f;
       
    }



    public void PlaySfx(int AS, int S, float V)
    {
        soundSrc[AS].Stop();
        soundSrc[AS].volume = V;
        soundSrc[AS].PlayOneShot(sfx[S]);
    }

    public void UISfx(int i)
        {
        if(on)
        PlaySfx(3,i,0.5f);
        else
        {
            on = true;
        }
    }
}
