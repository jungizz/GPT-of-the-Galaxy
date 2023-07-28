using System;
using UnityEngine;

public class MovingGodot : MonoBehaviour
{

    Vector3 final = new Vector3(13.9f, -2.1f, -1.9f);

    public GameObject pannel;

    void Start()
    {
        transform.position = new Vector3(32.6f, -68.3f, -48.3f);
        Invoke("setActive", 4);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, final, 0.07f);
    }

    void setActive()
    {
        pannel.SetActive(true);
    }
}
