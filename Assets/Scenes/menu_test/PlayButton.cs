using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnButtonDown()
    {
        SceneManager.LoadScene("GameLvl");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
