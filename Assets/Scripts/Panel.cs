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
    public GameObject info_info4;
    public GameObject info_info5;
    public GameObject info_info6;

    public GameObject next;
    public GameObject next2;

    public GameObject info2_info;
    public GameObject info2_info2;
    public GameObject info2_info3;

    public GameObject info2_Panel;
    public GameObject info2_Panel2;
    public GameObject info2_Panel3;

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

    public void NextButton()
    {
        next.SetActive(true);
        next2.SetActive(false);
        sound.Play();
    }

    public void NextButton2()
    {
        next.SetActive(false);
        next2.SetActive(true);
        sound.Play();
    }

    //패널 여는 기능

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

    //내부구조에서 세부 정보 패널 여는 기능
    public void OpenInfo2_Panel()
    {
        infoPanel2.SetActive(false);
        info2_Panel.SetActive(true);
        sound.Play();
    }

    public void OpenInfo2_Panel2()
    {
        infoPanel2.SetActive(false);
        info2_Panel2.SetActive(true);
        sound.Play();
    }

    public void OpenInfo2_Panel3()
    {
        infoPanel2.SetActive(false);
        info2_Panel3.SetActive(true);
        sound.Play();
    }

    //텍스트 여는 기능

    public void OpenInfo_Info1()
    {
        info_info.SetActive(true);
        info_info2.SetActive(false);
        if (info_info3 != null)
            info_info3.SetActive(false);
        if (info_info4 != null)
            info_info4.SetActive(false);
        if (info_info5 != null)
            info_info5.SetActive(false);
        if (info_info6 != null)
            info_info6.SetActive(false);
        sound.Play();
    }

    public void OpenInfo_Info2()
    {
        info_info.SetActive(false);
        info_info2.SetActive(true);
        if (info_info3 != null)
            info_info3.SetActive(false);
        if (info_info4 != null)
            info_info4.SetActive(false);
        if (info_info5 != null)
            info_info5.SetActive(false);
        if (info_info6 != null)
            info_info6.SetActive(false);
        sound.Play();
    }

    public void OpenInfo_Info3()
    {
        info_info.SetActive(false);
        info_info2.SetActive(false);
        if (info_info3 != null)
            info_info3.SetActive(true);
        if (info_info4 != null)
            info_info4.SetActive(false);
        if (info_info5 != null)
            info_info5.SetActive(false);
        if (info_info6 != null)
            info_info6.SetActive(false);
        sound.Play();
    }

    public void OpenInfo_Info4()
    {
        info_info.SetActive(false);
        info_info2.SetActive(false);
        if (info_info3 != null)
            info_info3.SetActive(false);
        if (info_info4 != null)
            info_info4.SetActive(true);
        if (info_info5 != null)
            info_info5.SetActive(false);
        if (info_info6 != null)
            info_info6.SetActive(false);
        sound.Play();
    }

    public void OpenInfo_Info5()
    {
        info_info.SetActive(false);
        info_info2.SetActive(false);
        if (info_info3 != null)
            info_info3.SetActive(false);
        if (info_info4 != null)
            info_info4.SetActive(false);
        if (info_info5 != null)
            info_info5.SetActive(true);
        if (info_info6 != null)
            info_info6.SetActive(false);
        sound.Play();
    }

    public void OpenInfo_Info6()
    {
        info_info.SetActive(false);
        info_info2.SetActive(false);
        if (info_info3 != null)
            info_info3.SetActive(false);
        if (info_info4 != null)
            info_info4.SetActive(false);
        if (info_info5 != null)
            info_info5.SetActive(false);
        if (info_info6 != null)
            info_info6.SetActive(true);
        sound.Play();
    }


    public void OpenInfo2_Info1()
    {
        info2_info.SetActive(true);
        info2_info2.SetActive(false);
        if (info2_info3 != null)
            info2_info3.SetActive(false);
        sound.Play();
    }

    public void OpenInfo2_Info2()
    {
        info2_info.SetActive(false);
        info2_info2.SetActive(true);
        if (info2_info3 != null)
            info2_info3.SetActive(false);
        sound.Play();
    }

    public void OpenInfo2_Info3()
    {
        info2_info.SetActive(false);
        info2_info2.SetActive(false);
        if (info2_info3 != null)
            info2_info3.SetActive(true);
        sound.Play();
    }

    //이전 패널로 가는 기능

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

    //내부구조에서 이전 패널로 가는 기능

    public void BackInfo2_Panel1()
    {
        info2_Panel.SetActive(false);
        infoPanel2.SetActive(true);
        sound.Play();
    }

    public void BackInfo2_Panel2()
    {
        info2_Panel2.SetActive(false);
        infoPanel2.SetActive(true);
        sound.Play();
    }

    public void BackInfo2_Panel3()
    {
        info2_Panel3.SetActive(false);
        infoPanel2.SetActive(true);
        sound.Play();
    }
}
