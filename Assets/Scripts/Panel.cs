using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject panelbutton;
    public GameObject panel;
    public GameObject infoPanel1;
    public GameObject infoPanel2;
    public GameObject info_info;
    public GameObject info_info2;
    public GameObject info_info3;

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

    public void OpenInfoPanel2()
    {
        panel.SetActive(false);
        infoPanel2.SetActive(true);
        sound.Play();
    }

    public void OpenInfo_Info1()
    {
        info_info.SetActive(true);
        info_info2.SetActive(false);
        info_info3.SetActive(false);
        sound.Play();
    }

    public void OpenInfo_Info2()
    {
        info_info.SetActive(false);
        info_info2.SetActive(true);
        info_info3.SetActive(false);
        sound.Play();
    }

    public void OpenInfo_Info3()
    {
        info_info.SetActive(false);
        info_info2.SetActive(false);
        info_info3.SetActive(true);
        sound.Play();
    }

    public void BackInfoPanel1()
    {
        infoPanel1.SetActive(false);
        panel.SetActive(true);
        sound.Play();
    }

    public void BackInfoPanel2()
    {
        infoPanel2.SetActive(false);
        panel.SetActive(true);
        sound.Play();
    }
}
