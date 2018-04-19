using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    private AM AudioManager;
    public bool EMGT = true;
    public GameObject SM;
    public GameObject MM;
    public GameObject PM;
    public GameObject TT;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MultiGame()
    {
        SceneManager.LoadScene(2);
    }
    public void kim()
    {
        SceneManager.LoadScene(7);
    }
    public void kim2()
    {
        SceneManager.LoadScene(10);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void EMG()
    {
        if (EMGT)
        {
           SM.SetActive(true);
           MM.SetActive(false);
           PM.SetActive(false);
           TT.SetActive(false);
        }
        else
            PM.SetActive(true);
            MM.SetActive(false);

        return;
    }
    public void Start()
    {
        AudioManager = GameObject.Find("AM").GetComponent<AM>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            AudioManager.soundSrc[0].clip = AudioManager.sfx[4];
            AudioManager.soundSrc[0].Play();
        }
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
