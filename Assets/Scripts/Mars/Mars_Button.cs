using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mars_Button : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Intro_Button()
    {
        GameObject.Find("Mars_Canvas").transform.GetChild(0).gameObject.SetActive(false);
    }
}
