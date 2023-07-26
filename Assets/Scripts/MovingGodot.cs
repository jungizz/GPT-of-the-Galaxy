using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Diagnostics;
//using System.Security.Cryptography;
using UnityEngine;

public class MovingGodot : MonoBehaviour
{

    Vector3 final = new Vector3(13.9f, -2.1f, -1.9f);
    public GameObject introText;

    void Start()
    {
        transform.position = new Vector3(32.6f, -68.3f, -48.3f);
        Invoke("setActive", 4);
    }

    void Update()
    {
        Vector3 speed = new Vector3(30.6f, -54.4f, 36.8f);
        transform.position = Vector3.Lerp(transform.position, final, 0.07f);
    }

    void setActive()
    {
        introText.SetActive(true);
    }
}
