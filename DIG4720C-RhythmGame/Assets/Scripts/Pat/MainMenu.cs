using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    private AM AudioManager;

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
        SceneManager.LoadScene(9);
    }
    public void kim2()
    {
        SceneManager.LoadScene(10);
    }
    public void QuitGame()
    {
        Application.Quit();
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
}
