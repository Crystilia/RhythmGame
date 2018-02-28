using UnityEngine.Audio;
using UnityEngine;

public class AM : MonoBehaviour {

    public AudioClip[] sfx;
    public AudioSource[] soundSrc;

    public static AM am;
	// Use this for initialization
	void Awake () {
        
        if(am == null)
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
	}
	
    public void PlaySfx(int AS, int S, int V)
    {
        soundSrc[AS].volume = V;
        soundSrc[AS].PlayOneShot(sfx[S]);
    }
}
