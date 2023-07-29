using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Godot : MonoBehaviour
{
    public bool Godotbuttonflag = false;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GodotPop()
    {
        Godotbuttonflag = !Godotbuttonflag;

        if (Godotbuttonflag)
            button.SetActive(true);
        else
            button.SetActive(false);
    }
}
