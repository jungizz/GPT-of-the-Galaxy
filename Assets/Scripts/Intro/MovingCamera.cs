using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{

    Vector3 Camerafinal = new Vector3(8.01f, 17.75f, -13.95f);

    void Start()
    {
        transform.position = new Vector3(100.7f, 97.5f, -84.9f);
    }

    void Update()
    {
        Vector3 speed = Vector3.zero;
        transform.position = Vector3.Slerp(transform.position, Camerafinal, 0.01f);
       // Vector3 speed = Vector3.one; // (0,0,0) 은 .zero 로도 표현가능
       // transform.position = Vector3.SmoothDamp(transform.position, Camerafinal, ref speed, 0.00001f);
    }

}