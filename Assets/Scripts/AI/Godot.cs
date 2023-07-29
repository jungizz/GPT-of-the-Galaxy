using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Godot : MonoBehaviour
{
    public GameObject Qestion_button;
    public GameObject Back_button;
    public GameObject Close_button;
    public GameObject GPTUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void GodotPopup()
    {
        Qestion_button.SetActive(true);
        Back_button.SetActive(true);
        Close_button.SetActive(true);

    }

    public void GodotPopdown()
    {
        Qestion_button.SetActive(false);
        Back_button.SetActive(false);
        Close_button.SetActive(false);
        GPTUI.SetActive(false);
    }

    public void backtospace()
    {
        SceneManager.LoadScene("Space");   
    }

    public void GPTUIup()
    {
        Qestion_button.SetActive(false);
        Back_button.SetActive(false);
        GPTUI.SetActive(true);
    }
}
