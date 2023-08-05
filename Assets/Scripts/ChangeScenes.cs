using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void changeToIntro2()
    {
        SceneManager.LoadScene("Intro2");
    }

    public void changeToOption()
    {
        SceneManager.LoadScene("Option");
    }

    public void changeToIntro1()
    {
        SceneManager.LoadScene("Intro1");
    }

    public void changeToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
