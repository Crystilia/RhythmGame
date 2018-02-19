using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

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
}
