using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMenu : MonoBehaviour {


    public void Char1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Backbutton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
