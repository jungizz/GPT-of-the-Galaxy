using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject panelbutton;
    public GameObject panel;
    public GameObject infoPanel1;
    public GameObject infoPanel2;

    public AudioSource sound;

    public void OpenPanel()
    {
        panelbutton.SetActive(false);
        panel.SetActive(true);
        sound.Play();
    }

    public void BackPanel()
    {
        panel.SetActive(false);
        panelbutton.SetActive(true);
        sound.Play();
    }

    public void OpenInfoPanel1()
    {
        panel.SetActive(false);
        infoPanel1.SetActive(true);
        sound.Play();
    }

    public void BackInfoPanel1()
    {
        infoPanel1.SetActive(false);
        panel.SetActive(true);
        sound.Play();
    }

    public void OpenInfoPanel2()
    {
        panel.SetActive(false);
        infoPanel2.SetActive(true);
        sound.Play();
    }

    public void BackInfoPanel2()
    {
        infoPanel2.SetActive(false);
        panel.SetActive(true);
        sound.Play();
    }
}
